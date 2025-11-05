using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //TODO tmp
    [SerializeField]
    private InventorySlotView slotView;


    [SerializeField]
    private Vector2Int gridPosition;


    private InventoryItem item;

    public InventoryItem InventoryItem { get { return item; } }
    public Item Item { get { return item != null ? item.Item : null; } }
    public void Construct(int x, int y)
    {
        gridPosition = new Vector2Int(x, y);
    }

    public bool AddItem(InventoryItem item)
    {
        if (this.item != null)
            return false;
        slotView.ShowView(item);
        this.item = item;
        return true;
    }

    public void RemoveItem()
    {
        this.item = null;
        slotView.ClearView();
        //Clear view
    }

    public int IncreaseItemSize(int value)
    {
        int residue = 0;
        item.CurrentSize += value;
        if (item.CurrentSize > item.Item.StackSize)
        {
            residue = item.CurrentSize - item.Item.StackSize;
            item.CurrentSize = item.Item.StackSize;
        }
        slotView.UpdateCount(item.CurrentSize);
        return residue;
    }

    public int GetItemCount()
    {
        return item == null ? 0 : item.CurrentSize;
    }

    public bool IsFullStack()
    {
        return item.CurrentSize == item.Item.StackSize;
    }
}
