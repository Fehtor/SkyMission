using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Heal,
    Mana
}


public class Item : MonoBehaviour
{
    public ItemType type;
    public string nameOfItem;
    private int count;
    public string Thingname;

    public void ChangeCount(int value)
    {
        count += value;
    }

    public int GetCount()
    {
        return count;
    }
}
