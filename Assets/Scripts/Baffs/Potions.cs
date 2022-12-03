using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Potion
{
    HealthPotion,
    ManaPotion
}

public class Potions : MonoBehaviour
{
    public Potion potion;
    private InventorySystem InventorySystem;
    private GameObject InventoryManager;
    [SerializeField] private Image ownIMG;
    [SerializeField] private GoodSCR goodTypeOfPotion;

    [SerializeField] private Image activeLetter;

    [SerializeField] private int radius;

    private bool wasAdded;

    private bool isGrounded;
    [SerializeField] private LayerMask whatIsGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
       
        InventoryManager = GameObject.FindGameObjectWithTag("InventoryManager");
        InventorySystem = InventoryManager.GetComponent<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(transform.position, radius, whatIsGrounded);
        if (isGrounded)
        {
            activeLetter.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                AddToInventory();
            }
        }
        else
        {
            activeLetter.gameObject.SetActive(false);
        }
    }

    

    public void AddToInventory()
    {
        if (!wasAdded)
        {
            InventorySystem.ReceiveItem(goodTypeOfPotion, ownIMG);
            Destroy(gameObject);
            wasAdded = true;
        }
        
    }
}
