using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ChestLevel
{
    first,
    second,
    third,
    fourth
}

public class Chests : MonoBehaviour
{
    public ChestLevel chestLevel;

    public GameObject openedChest;
    public Image pressButton;
    int radius = 3;
    private Collider2D findedGameObj;

    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        
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
                Instantiate(openedChest, transform.position, Quaternion.identity);
                Destroy(gameObject);
                switch(chestLevel)
                {
                    case ChestLevel.first:
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        break;

                    case ChestLevel.second:
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        break;

                    case ChestLevel.third:
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        break;
                    case ChestLevel.fourth:
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        Instantiate(coin, transform.position, Quaternion.identity);
                        break;
                }
            }
        }
        else
        {
            pressButton.gameObject.SetActive(false);
        }
    }
}
