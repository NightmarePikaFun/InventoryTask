using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    [SerializeField]
    private SpawnItemView spawnItemView;
    [SerializeField]
    private TMP_Text itemName;
    [SerializeField]
    private Button spawnItem;
    [SerializeField]
    private Button spawnItemInSlot;
    [SerializeField]
    private StackableItem item;


    private void Awake()
    {
        spawnItem.onClick.AddListener(SpawnItem);
        spawnItemInSlot.onClick.AddListener(SpawnItemInSlot);
        itemName.text = item.Name;
    }

    private void SpawnItem()
    {
        spawnItemView.AddItem(item);
    }

    private void SpawnItemInSlot()
    {
        spawnItemView.AddItemWithConfig(item);
    }
}
