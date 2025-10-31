using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject
{
    public string Name;
    public Image Icon;
    public string Description;
    public ItemType Type;
}

public enum ItemType
{
    quest,
    potion,
    weapon,
    food,
}
