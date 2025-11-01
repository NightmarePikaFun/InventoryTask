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
}

public class StackableItem : Item
{
    public int StackSize;
}

public class InventoryItem
{
    public int CurrentSize;
    public StackableItem Item;
}

public enum ItemType
{
    quest,
    potion,
    weapon,
    food,
}
