using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //TODO tmp
    [SerializeField]
    private Image image;
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private Vector2Int gridPosition;

    private InventoryItem item;

    public Item Item { get { return item != null ? item.Item : null; } }
    public void Construct(int x, int y)
    {
        gridPosition = new Vector2Int(x, y);
    }

    public bool AddItem(InventoryItem item)
    {
        if (this.item != null)
            return false;
        this.item = item;
        image.sprite = item.Item.Icon;
        text.text = item.CurrentSize.ToString();
        return true;
    }

    public int IncreaseItemSize(int value)
    {
        int residue = 0;
        item.CurrentSize += value;
        if (item.CurrentSize > item.Item.StackSize)
        {
            residue = item.CurrentSize - item.Item.StackSize;
            item.CurrentSize = item.Item.StackSize;
        }
        text.text = item.CurrentSize.ToString();
        return residue;
    }

    public bool IsFullStack()
    {
        return item.CurrentSize == item.Item.StackSize;
    }
}
