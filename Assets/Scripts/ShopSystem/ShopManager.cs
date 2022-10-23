using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Dictionary<GoodSCR, Button> dict = new Dictionary<GoodSCR, Button>();
    public List<Button> buttonList = new List<Button>();
    private int i = 0;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GoodSCR heal = new GoodSCR();
        heal.name = "HealPotion";
        heal.changeCost(20);
        heal.countChange(3);
        AddButton(heal, buttonList[i]);
        

        GoodSCR mana = new GoodSCR();
        mana.name = "ManaPotion";
        mana.changeCost(20);
        mana.countChange(3);
        //   AddButton(heal, buttonList[i]);

        StartCoroutine("RegenGoods");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void AddButton(GoodSCR good, Button button)
    {
        dict[good] = button;
        i++;
    }

    public void ButtonReceive(GameObject gameObj)
    {
        
        
        foreach (var item in dict)
        {
            if (item.Value.gameObject == gameObj)
            {
                BuyGood(item.Key);
                
            }
        }
    }

    public void BuyGood(GoodSCR good)
    {
        good.countChange(good.GetCount() - 1);
        Wallet wallet = player.GetComponent<Wallet>();
        wallet.MoneySpend(good.GetCost());
    }

    IEnumerator RegenGoods()
    {
        yield return new WaitForSeconds(600);
        foreach (var item in dict)
        {
            item.Key.countChange(item.Key.GetCount() + 1);
        }
    }
}
