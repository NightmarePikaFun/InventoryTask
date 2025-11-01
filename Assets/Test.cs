using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup parent;
    [SerializeField]
    private Vector2Int inventorySize;
    [SerializeField]
    private Sprite icon;

    private Inventory inventory;

    InventoryItem iItem = new InventoryItem();
    StackableItem sItem;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        parent.constraintCount = inventorySize.x;
        inventory.Construct("Test", inventorySize, parent.transform);

        sItem = new StackableItem();
        sItem.name = "Test";
        sItem.StackSize = 4;
        sItem.Icon = icon;
        
        iItem.Item = sItem;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            iItem = new InventoryItem();
            iItem.CurrentSize = 1;
            iItem.Item = sItem;
            Additem(iItem);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            iItem = new InventoryItem();
            iItem.CurrentSize = 2;
            iItem.Item = sItem;
            Additem(iItem);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            iItem = new InventoryItem();
            iItem.CurrentSize = 3;
            iItem.Item = sItem;
            Additem(iItem);
        }
    }

    private void Additem(InventoryItem item)
    {
        if (!inventory.AddItem(ref iItem))
            Debug.Log("Can't sotre more items, item residue: " + iItem.CurrentSize);
    }
}
