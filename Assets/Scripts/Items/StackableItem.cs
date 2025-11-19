using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStackable", menuName = "StackableItem", order = 1)]
public class StackableItem : Item
{
    public int StackSize;

    public override void UseItem()
    {
        Debug.Log("Use " + Name);
    }
}
