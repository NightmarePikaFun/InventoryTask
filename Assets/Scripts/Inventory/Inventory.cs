using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private string inventoryName;
    private Vector2Int inventorySize;
    private Transform inventoryParent;

    private InventorySlot[][] inventorySlots;

    public void Construct(string name, Vector2Int size, Transform parent)
    {
        inventoryName = name;
        inventorySize = size;
        inventoryParent = parent;
        inventorySlots = new InventorySlot[inventorySize.y][];
        for (int i = 0; i < inventorySize.y; i++)
        {
            inventorySlots[i] = new InventorySlot[inventorySize.x];
            for (int j = 0; j < inventorySize.x; j++)
            {
                inventorySlots[i][j] = HelpManager.Instance.SpawnPrefab(HelpManager.Instance.SlotPrefab, inventoryParent);
                inventorySlots[i][j].name = i + "_" + j;
                inventorySlots[i][j].Construct(i, j);
            }
        }
    }

    public bool AddItem(ref InventoryItem item, Vector2Int slot)
    {
        bool isStored = false;
        int residue = 0;
        isStored = inventorySlots[slot.y][slot.x].AddItem(item).Item1;
        if (!isStored)
            if (inventorySlots[slot.y][slot.x].Item == item.Item)
                residue = inventorySlots[slot.y][slot.x].IncreaseItemSize(item.CurrentSize);
        return isStored && residue == 0;
    }

    public bool AddItem(ref InventoryItem item)
    {
        if (!AddToStoredSlot(ref item))
            if (!AddToFreeSlot(ref item))
                return false;
        return true;
    }

    private bool AddToStoredSlot(ref InventoryItem item)
    {
        bool isComplete = false;
        for (int i = 0; i < inventorySize.y; i++)
        {
            for (int j = 0; j < inventorySize.x; j++)
            {
                if (inventorySlots[i][j].Item == item.Item && !inventorySlots[i][j].IsFullStack())
                {
                    int residue = inventorySlots[i][j].IncreaseItemSize(item.CurrentSize);
                    if (residue > 0)
                    {
                        item.CurrentSize = residue;
                    }
                    else
                    {
                        isComplete = true;
                        break;
                    }
                }
            }
            if (isComplete)
                break;
        }
        return isComplete;
    }

    private bool AddToFreeSlot(ref InventoryItem item)
    {
        bool isComplete = false;
        for (int i = 0; i < inventorySize.y; i++)
        {
            for (int j = 0; j < inventorySize.x; j++)
            {
                if (inventorySlots[i][j].Item == null)
                {
                    inventorySlots[i][j].AddItem(item);
                    isComplete = true;
                    break;
                }
            }
            if (isComplete)
                break;
        }
        return isComplete;
    }

    public void RemoveItem(Vector2Int slot)
    {

    }
}
