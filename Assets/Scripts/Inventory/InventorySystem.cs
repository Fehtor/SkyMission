using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    
    private bool isOpened = false;
    [SerializeField] GameObject InventoryPanel;

    private List<Good> Items = new List<Good>();


    [SerializeField]private List<GameObject> Cells = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isOpened)
        {
            InventoryPanel.SetActive(true);
            isOpened = true;
        }

        if (Input.GetKeyDown(KeyCode.I) && isOpened)
        {
            InventoryPanel.SetActive(false);
        }
    }

    public void ReceiveItem(GoodSCR good)
    {
        foreach (var cell in Cells)
        {
            CellSCR newCell = cell.GetComponent<CellSCR>();

            if(good.GetGoodType() == newCell.GetItemInCell().GetGoodType())
            {
                newCell.GetItemInCell().countChange(1);
                
                return;
            }
        }

        switch (good.GetGoodType())
        {
            case GoodType.Heal:
                GoodSCR HealItem = good;
                //HealItem.countChange()
                //Item Heal = new Item();
                //Heal.nameOfItem = good.name;
                //Heal.ChangeCount(1);
                //NewCellOccupation(Heal, null);
                //Items.Add(Heal);
                //Heal.type = ItemType.Heal; // cделать метод
                    
                break;
            case GoodType.Mana:
                Item Mana = new Item();
                Mana.nameOfItem = good.name;
                Mana.ChangeCount(1);
                Items.Add(Mana);
                Mana.type = ItemType.Mana;

                break;
            default:
                break;
        }
        return;
    }

    public void NewCellOccupation(Item item, Image itemImage)
    {
        if (item.GetCount() == 1)
        {
            foreach (var cell in Cells)
            {
                if (!cell.occupied)
                {
                    cell.SetItem(item);
                    cell.SetImage(itemImage);
                    cell.occupied = true;
                    cell.countText.text = item.GetCount().ToString();
                    return;
                }
            }
        }
        
            foreach (var cell in Cells)
            {
                if (cell.GetItemInCell().type == item.type)
                {
                    
                    cell.GetItemInCell().ChangeCount(item.GetCount());
                    cell.countText.text = item.GetCount().ToString();
                    
                }
            }
    }
}
