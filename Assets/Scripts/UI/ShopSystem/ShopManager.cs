using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    
    public List<Button> buttonList = new List<Button>();
    private int i = 0;

    private GameObject InventoryManager;
    private InventorySystem Inventory;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InventoryManager = GameObject.FindGameObjectWithTag("InventoryManager");
        Inventory = InventoryManager.GetComponent<InventorySystem>();

        //StartCoroutine("RegenGoods");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyGood(GoodSCR good)
    {
        Wallet wallet = player.GetComponent<Wallet>();
        if (wallet.ChangeMoney(good.GetCost()))
        {
            good.countChange(-1);
            Inventory.ReceiveItem(good, good.myImage);
        }
    }

   /* IEnumerator RegenGoods()
    {
        yield return new WaitForSeconds(600);
        foreach (var item in dict)
        {
            item.Key.countChange(1);
        }
    }*/
}
