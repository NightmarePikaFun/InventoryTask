using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragModel : MonoBehaviour
{
    [SerializeField]
    private DragItem draggableItem;

    public InventoryItem currentItem;
    public InventorySlot oldSlot;
    public InventorySlot newSlot;

    public bool IsMove => draggableItem.IsMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMovableItem(InventoryItem item, InventorySlot slot)
    {
        
        Debug.Log("+");
        currentItem = item;
        oldSlot = slot;
        draggableItem.ActivateObject(item);
        oldSlot.RemoveItem();
    }

    public void StoreItem()
    {
        if(newSlot == null)
        {
            oldSlot.AddItem(currentItem);
        }
        else
        {
            Tuple<bool, int> itemResult = newSlot.AddItem(currentItem);
            if (!itemResult.Item1)
            {
                currentItem.CurrentSize = itemResult.Item2;
                oldSlot.AddItem(currentItem);
            }
            oldSlot = null;
        }
        newSlot = null;
        currentItem = null;
        draggableItem.Hide();
    }

    public void SetNewSlot(InventorySlot slot)
    {
        if(IsMove)
            newSlot = slot;
    }

    public void RemoveNewSlot()
    {
        if (IsMove)
            newSlot = null;
    }
}
