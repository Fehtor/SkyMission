using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellSCR : MonoBehaviour
{
    [SerializeField]private Image imageOfItem;
    public bool occupied = false;
    private GoodSCR itemInCell;

    public Text countText;

    public void Update()
    {
       
    }


    public GoodSCR GetItemInCell()
    {
        return itemInCell;
    }

    public void SetItem(Item newItem)
    {
        itemInCell = newItem;
    }

    public void SetImage(Image newImage)
    {
        imageOfItem = newImage;
    }
}
