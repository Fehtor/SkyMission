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

    public void Start()
    {
        
    }


    public GoodSCR GetItemInCell()
    {
        return itemInCell;
    }

    public void SetItem(GoodSCR newItem)
    {
        itemInCell = newItem;
    }

    public void SetImage(Image newImage)
    {
        imageOfItem.sprite = newImage.sprite;
        imageOfItem.color = new Color(255f, 255f, 255f, 255f);
    }

    public void DeleteImage()
    {
        imageOfItem.sprite = null;
        imageOfItem.color = new Color(255f, 255f, 255f, 0f);
    }
}
