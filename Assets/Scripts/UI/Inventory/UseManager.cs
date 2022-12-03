using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseManager : MonoBehaviour
{
   
    [SerializeField] private InventorySystem InventorySystem;
    
   
    public void UseHeal(List<CellSCR> Cells, BaffSystem baffSystem)
    {
        foreach (var cell in Cells)
        {
            if (cell.occupied)
            {
                Debug.Log(cell.GetItemInCell().GetGoodType());

                if (cell.GetItemInCell().GetGoodType() == GoodType.Heal)
                {
                    baffSystem.ReceiveObjects(550, BaffType.playerHealthDebaff);
                   InventorySystem.DeleteItem(cell);
                }
            }

        }
    }
    public void UseMana(List<CellSCR>  Cells, BaffSystem baffSystem)
    {
        foreach (var cell in Cells)
        {
            if (cell.occupied)
            {
                if (cell.GetItemInCell().GetGoodType() == GoodType.Mana)
                {
                    baffSystem.ReceiveObjects(550, BaffType.ManaBaff);
                    InventorySystem.DeleteItem(cell);
                }
            }

        }
    }
}
