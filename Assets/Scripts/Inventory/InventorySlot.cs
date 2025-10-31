using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Vector2Int gridPosition;

    private Item item;
    private int currentSize;
    public void Construct(int x, int y)
    {
        gridPosition = new Vector2Int(x, y);
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
