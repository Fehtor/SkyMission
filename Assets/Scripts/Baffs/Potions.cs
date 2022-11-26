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
    [SerializeField] private InventorySystem InventorySystem;
    [SerializeField] private Image ownIMG;
    [SerializeField] private GoodSCR goodTypeOfPotion;

    [SerializeField] private Image activeLetter;

    private Collider2D findedGameObj;
    [SerializeField] private int radius;

    private bool wasAdded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        findedGameObj = Physics2D.OverlapCircle(transform.position, radius);
        if (findedGameObj.gameObject.tag == "Player")
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
