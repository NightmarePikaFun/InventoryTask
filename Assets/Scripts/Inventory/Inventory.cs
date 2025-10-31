using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private string inventoryName;
    [SerializeField]
    private Vector2Int inventorySize;
    [SerializeField]
    private InventorySlot slotPrefab;
    [SerializeField]
    private Transform inventoryParent;

    private InventorySlot[][] inventorySlots;

    private void Construct()
    {
        inventorySlots = new InventorySlot[inventorySize.x][];
        for (int i = 0; i < inventorySize.x; i++)
        {
            inventorySlots[i] = new InventorySlot[inventorySize.y];
            for (int j = 0; j < inventorySize.y; j++)
            {
                inventorySlots[i][j] = Instantiate(slotPrefab, inventoryParent);
                inventorySlots[i][j].Construct(i, j);
            }
        }
    }

    public void AddItem()
    {

    }

    public void RemoveItem()
    {

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
