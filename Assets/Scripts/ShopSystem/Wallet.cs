using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    private int moneyCount = 100;

    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoneyAdd(int moneyToAdd)
    {
        moneyCount += moneyToAdd; 
    }

    public void MoneySpend(int moneyToSpend)
    {
        moneyCount -= moneyToSpend;
    }

    public int GetMoney()
    {
        return moneyCount;
    }

  
}
