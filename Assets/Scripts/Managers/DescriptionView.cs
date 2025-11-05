using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class DescriptionView : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup group;
    [SerializeField]
    private TMP_Text itemName;
    [SerializeField]
    private TMP_Text itemDescription;
    [SerializeField]
    private RectTransform descriptionTransform;

    public void Show(InventorySlot slot)
    {
        if (slot.Item == null)
            return;
        transform.position = new Vector3(slot.transform.position.x+ descriptionTransform.rect.width/2+5, slot.transform.position.y);
        itemName.text = slot.Item.Name;
        itemDescription.text = slot.Item.Description;
        //itemCount.text = slot.GetItemCount().ToString();
        group.alpha =  1.0f;
    }

    public void Hide()
    {
        group.alpha = 0.0f;
        transform.position = new Vector3(-1000, -1000);
    }
}