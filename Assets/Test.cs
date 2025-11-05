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

    private Inventory inventory;


    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        parent.constraintCount = inventorySize.x;
        inventory.Construct("Test", inventorySize, parent.transform);

        /*sItem = new StackableItem();
        sItem.Name = "Test";
        sItem.StackSize = 4;
        sItem.Icon = icon;
        sItem.Description = "Test description";*/
        
        //iItem.Item = sItem[0];
        

    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.A))
        {
            iItem = new InventoryItem();
            iItem.CurrentSize = 1;
            iItem.Item = sItem[0];
            Additem(iItem);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            iItem = new InventoryItem();
            iItem.CurrentSize = 2;
            iItem.Item = sItem[0];
            Additem(iItem);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            iItem = new InventoryItem();
            iItem.CurrentSize = 3;
            iItem.Item = sItem[0];
            Additem(iItem);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {

            iItem = new InventoryItem();
            iItem.CurrentSize = 1;
            iItem.Item = sItem[0];
            Additem(iItem, new Vector2Int(0,0));
        }*/
    }

    public void Additem(InventoryItem item)
    {
        if (!inventory.AddItem(ref item))
            Debug.Log("Can't sotre more items, item residue: " + item.CurrentSize);
    }

    public void Additem(InventoryItem item, Vector2Int slot)
    {
        if (!inventory.AddItem(ref item, slot))
            Debug.Log("Can't sotre more items, item residue: " + item.CurrentSize);
    }
}
