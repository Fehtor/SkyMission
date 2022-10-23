using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodSCR : MonoBehaviour
{
    public string name;
    private int cost;
    private int count;

    public Button button;
    public void changeCost(int intToChange)
    {
        cost = intToChange;
    }

    public void countChange(int intToChange)
    {
        count = intToChange;
    }

    public int GetCost()
    {
        return cost;
    }

    public int GetCount()
    {
        return count;
    }

    
}
