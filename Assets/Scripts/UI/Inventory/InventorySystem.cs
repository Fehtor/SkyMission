using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    private Vector3 playerPos;
    [SerializeField] GameObject Player;
    [SerializeField] BaffSystem baffSystem;

    private bool isOpened = false;
    [SerializeField] GameObject InventoryPanel;

    private List<Good> Items = new List<Good>();

    private List<CellSCR> Cells = new List<CellSCR>();

    private InventoryAnim InventoryAnim;
    // Start is called before the first frame update
    void Start()
    {
        InventoryAnim = InventoryPanel.GetComponent<InventoryAnim>();

        GameObject[] cellObjects = GameObject.FindGameObjectsWithTag("Cell");
        foreach (var cellObj in cellObjects)
        {
            Cells.Add(cellObj.GetComponent<CellSCR>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isOpened)
        {
            InventoryAnim.EnableAnim();
            isOpened = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpened)
        {
            isOpened = false;
            InventoryAnim.DisableAnim();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UseHeal();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            UseMana();
        }

        /*  if (Input.GetKeyDown(KeyCode.Mouse0))
          {
              foreach (var cell in Cells)
              {
                   Debug.Log(cell.gameObject.transform.position + "" + "" + Camera.main.ScreenToWorldPoint(Input.mousePosition));
                  if(cell.gameObject.transform.position == Camera.main.ScreenToWorldPoint(Input.mousePosition))
                  {
                      Debug.Log("fhdjgfjgdf");

                  }
              }
          }*/

        playerPos = Player.transform.position;
    }

    public void ReceiveItem(GoodSCR good, Image goodImage)
    {
        foreach (var cell in Cells)
        {
            if(cell.occupied)
            {
                Debug.Log(cell.GetItemInCell().GetGoodType());
                if (good.GetGoodType() == cell.GetItemInCell().GetGoodType())
                {
                    cell.GetItemInCell().countChange(1);
                    cell.countText.text = cell.GetItemInCell().GetCount().ToString();
                    return;
                }
            }
        }

        switch (good.GetGoodType())
        {
            case GoodType.Heal:
                GoodSCR HealItem = new GoodSCR(1, GoodType.Heal);
                HealItem.changeCost(good.GetCost() * 0.8f);
                NewCellOccupation(HealItem, goodImage);
                
                break;
            case GoodType.Mana:
                GoodSCR ManaItem = new GoodSCR(1, GoodType.Mana);
                ManaItem.changeCost(good.GetCost() * 0.8f);
                NewCellOccupation(ManaItem, goodImage);

                break;
            default:
                break;
        }
        return;
    }

    public void NewCellOccupation(GoodSCR item, Image itemImage)
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
    public void DeleteItem(CellSCR cell)
    {
        if (cell.occupied)
        {
            if (cell.GetItemInCell().GetCount() == 1)
            {
                cell.SpawnYourItem(playerPos);
                cell.DeleteImage();
                cell.SetItem(null);
                cell.countText.text = 0.ToString();
                cell.occupied = false;

            }
            else
            {
                cell.SpawnYourItem(playerPos);
                cell.GetItemInCell().countChange(-1);
                cell.countText.text = cell.GetItemInCell().GetCount().ToString();
            }
        }
    }

    public void UseHeal()
    {
        foreach (var cell in Cells)
        {
            if (cell.occupied)
            {
                Debug.Log(cell.GetItemInCell().GetGoodType());
                
                if (cell.GetItemInCell().GetGoodType() == GoodType.Heal)
                {
                    baffSystem.ReceiveObjects(550, BaffType.playerHealthDebaff);
                    DeleteItem(cell);
                }
            }

        }
    }
    public void UseMana()
    {
        foreach (var cell in Cells)
        {
            if (cell.occupied)
            {
                if (cell.GetItemInCell().GetGoodType() == GoodType.Mana)
                {
                    baffSystem.ReceiveObjects(550, BaffType.ManaBaff);
                    DeleteItem(cell);
                }
            }

        }
    }

}
