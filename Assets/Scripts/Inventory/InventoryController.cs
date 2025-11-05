using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController
{
    private Item currentItem;
    private InventorySlot currentInventorySlot;

    public Transform slotTransform { get { return currentInventorySlot?.transform; } private set { } }

    public void SetCurrentItem(Item item)
    {
        currentItem = item;
    }

    public void SetCurrentSlot(InventorySlot slot) 
    {
        currentInventorySlot = slot;
    }

    public void ResetCurrentSlot()
    {
        //currentInventorySlot = null;
    }

    public void ResetCurrentItem()
    {
        currentItem = null;
    }

    public void UpdateSlotView()
    {
        currentInventorySlot.UpdateState();
    }

    public void UseItem()
    {
        currentInventorySlot.InventoryItem.UseItem();
        UpdateSlotView();
    }

    public void RemoveItem()
    {
        Debug.Log("Item " + currentInventorySlot.Item.Name + " destroyed!");
        currentInventorySlot.RemoveItem();
    }
}
