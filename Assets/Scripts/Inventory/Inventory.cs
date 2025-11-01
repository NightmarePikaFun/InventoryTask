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
        inventorySlots = new InventorySlot[inventorySize.x][];
        for (int i = 0; i < inventorySize.x; i++)
        {
            inventorySlots[i] = new InventorySlot[inventorySize.y];
            for (int j = 0; j < inventorySize.y; j++)
            {
                inventorySlots[i][j] = HelpManager.Instance.SpawnPrefab(HelpManager.Instance.SlotPrefab, inventoryParent);
                inventorySlots[i][j].Construct(i, j);
            }
        }
    }

    public bool AddItem(ref InventoryItem item, Vector2Int slot)
    {
        return inventorySlots[slot.x][slot.y].AddItem(item);
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
        for (int i = 0; i < inventorySize.x; i++)
        {
            for (int j = 0; j < inventorySize.y; j++)
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
        for (int i = 0; i < inventorySize.x; i++)
        {
            for (int j = 0; j < inventorySize.y; j++)
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
