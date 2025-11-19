using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
