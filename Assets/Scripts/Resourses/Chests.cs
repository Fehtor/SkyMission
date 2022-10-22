using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ChestLevel
{
    first = 1,
    second,
    third,
    fourth
}

public class Chests : MonoBehaviour
{
    public ChestLevel chestLevel;

    public Sprite openedChest;
    public Image pressButton;
    int radius = 3;
    private Collider2D findedGameObj;

    public GameObject coin;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        findedGameObj =  Physics2D.OverlapCircle(transform.position, radius);
        if(findedGameObj.gameObject.tag == "Player")
        {
            Debug.Log("HRHRHRRRRRR");
            pressButton.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                sr.sprite = openedChest;
                for(int i = 0; i < (int)chestLevel * 2; i++) 
                {
                    GameObject newCoin = Instantiate(coin, transform.position, Quaternion.identity);
                    newCoin.transform.position = Vector2.MoveTowards(newCoin.transform.position, Random.insideUnitCircle * 1.3f, 0.01f);
                    
                }
              
            }
        }
        else
        {
            pressButton.gameObject.SetActive(false);
        }
    }
}
