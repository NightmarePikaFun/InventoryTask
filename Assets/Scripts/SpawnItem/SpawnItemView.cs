using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemView : MonoBehaviour
{
    [SerializeField]
    private ItemConfig itemConfig;
    [SerializeField]
    private Test inventory;

    public void AddItem(StackableItem item)
    {
        InventoryItem invItem = new InventoryItem();
        invItem.Item = item;
        if (itemConfig.CanUseCount())
            invItem.CurrentSize = SetItemCount(invItem);
        else
            invItem.CurrentSize = 1;
        inventory.Additem(invItem);
    }

    public void AddItemWithConfig(StackableItem item)
    {
        InventoryItem invItem = new InventoryItem();
        invItem.Item = item;
        invItem.CurrentSize = SetItemCount(invItem); 
        inventory.Additem(invItem, itemConfig.GetSlot());
    }

    private int SetItemCount(InventoryItem item)
    {
        item.CurrentSize = itemConfig.GetCount();
        if (item.CurrentSize >= item.Item.StackSize)
            item.CurrentSize = item.Item.StackSize;
        return item.CurrentSize;
    }
}
