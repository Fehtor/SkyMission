using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GoodType
{
    Heal,
    Mana
}

public class GoodSCR : MonoBehaviour
{
    public string name;
    [SerializeField]private int cost;
    [SerializeField]private int count;
    [SerializeField] private GoodType type;
    
    public void changeCost(int intToChange)
    {
        cost = intToChange;
    }

    public bool countChange(int intToChange)
    {
        if(count < intToChange)
        {
            return false;
        }

        count += intToChange;
        return true;
    }

    public int GetCost()
    {
        return cost;
    }

    public int GetCount()
    {
        return count;
    }

    public GoodType GetGoodType()
    {
        return type;
    }
}
