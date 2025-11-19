using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public string Description;
    public ItemType Type;

    public virtual void UseItem()
    {

    }
}



public class InventoryItem
{
    public int CurrentSize;
    public StackableItem Item;

    public void UseItem()
    {
        Item.UseItem();
        CurrentSize -= 1;
    }
}

public enum ItemType
{
    quest,
    potion,
    weapon,
    food,
}