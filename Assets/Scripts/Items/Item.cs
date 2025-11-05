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

[CreateAssetMenu(fileName = "ItemStackable", menuName = "StackableItem", order = 1)]
public class StackableItem : Item
{
    public int StackSize;

    public override void UseItem()
    {
        Debug.Log("Use "+ Name);
    }
}

[CreateAssetMenu(fileName = "WeaponItem", menuName = "Weapon", order = 2)]
public class WeaponItem : StackableItem
{
    public readonly int StackSize = 1;

    public string AmmoType;//TODO it will be enum

    public override void UseItem()
    {
        Debug.Log("Equip " + Name);
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