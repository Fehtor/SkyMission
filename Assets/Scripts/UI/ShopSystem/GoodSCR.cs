using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GoodType
{
    Heal,
    Mana,
    None
}

public class GoodSCR : MonoBehaviour
{
    public string name;
    [SerializeField]private float cost;
    [SerializeField]private int count;
    [SerializeField] private GoodType goodType;

    public Image myImage;

    public GoodSCR()
    {
        count = 0;
        goodType = GoodType.None; 
    }

    public GoodSCR(int initialCount, GoodType type)
    {
        count = initialCount;
        goodType = type;
    }
    
    public void changeCost(float intToChange)
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

    public float GetCost()
    {
        return cost;
    }

    public int GetCount()
    {
        return count;
    }

    public GoodType GetGoodType()
    {
        return goodType;
    }
}
