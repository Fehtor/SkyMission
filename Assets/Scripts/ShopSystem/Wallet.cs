using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    private int moneyCount = 100;

    public Text moneyText;
    // Start is called before the first frame update
    
    public bool ChangeMoney(int value)
    {
        if(moneyCount < value)
        {
            return false;
        }

        moneyCount += value;
        return true;
    }

    public int GetMoney()
    {
        return moneyCount;
    }

  
}
