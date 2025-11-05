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
        invItem.CurrentSize = 1;
        inventory.Additem(invItem);
    }

    public void AddItemWithConfig(StackableItem item)
    {
        InventoryItem invItem = new InventoryItem();
        invItem.Item = item;
        invItem.CurrentSize = itemConfig.GetCount();
        if(invItem.CurrentSize > invItem.Item.StackSize)
            invItem.CurrentSize = invItem.Item.StackSize;
        inventory.Additem(invItem, itemConfig.GetSlot());
    }
}
