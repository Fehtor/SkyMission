using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] GameObject draggedItem;
    private Image draggedItemImage;
    [SerializeField] Sprite defaultSprite;

    [SerializeField] InventorySystem inventorySystem;
    private bool hasDropped;

    private CellSCR draggedCell;
    // Start is called before the first frame update
    void Start()
    {
       
        draggedItemImage = draggedItem.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dragging()
    {
        draggedItem.transform.position = Input.mousePosition;
    }

    public void BeginDrag(CellSCR cell)
    {
        if (cell.occupied)
        {
            draggedCell = cell;
            draggedItemImage.sprite = cell.GetImage().sprite;
        }
        Debug.Log("BeginDrag");
    }

    public void DragEnd(CellSCR cell)
    {
        Debug.Log("DragEnd");
        if(isMouseONCell() != null)
        {
            CellSCR droppedCell = isMouseONCell().GetComponent<CellSCR>();
            if(droppedCell != cell)
            {
                inventorySystem.addItemInCurrentCell(cell, droppedCell);
                Debug.Log("Return");
                draggedItemImage.sprite = defaultSprite;
                return;
            }
            draggedItemImage.sprite = defaultSprite;
            return;
        }
        draggedItemImage.sprite = defaultSprite;
        inventorySystem.DeleteItem(cell, true);
    }

    public GameObject isMouseONCell()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);

        for (int i = 0; i < results.Count; i++)
        {
            if(results[i].gameObject.tag == "Cell")
            {
                return results[i].gameObject;
            }
            
        }

        return null;
    } 
}
