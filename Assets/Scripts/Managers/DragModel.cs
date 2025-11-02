using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragModel : MonoBehaviour
{
    [SerializeField]
    private DragItem draggableItem;

    public InventoryItem currentItem;
    public InventorySlot oldSlot;
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
    }
}
