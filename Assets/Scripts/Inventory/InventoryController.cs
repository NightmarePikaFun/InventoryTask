using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Item currentItem;
    private InventorySlot currentInventorySlot;

    public void SetCurrentItem(Item item)
    {
        currentItem = item;
    }

    public void SetCurrentSlot(InventorySlot slot) 
    {
        currentInventorySlot = slot;
    }

    public void ResetCurrentItem()
    {
        currentItem = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
