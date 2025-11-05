using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings.SplashScreen;
using static UnityEditor.Progress;

public class InventorySlotView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private TMP_Text itemCount;
    [SerializeField]
    private InventorySlot slot;
    [SerializeField]
    private Button slotButton;

    private HelpManager helpManager => HelpManager.Instance;
    private DragModel dragModel => helpManager.DragModel;

    void Awake()
    {
        Debug.Log("Awake");
        //slotButton.onClick.AddListener(SelectItem);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (dragModel.IsMove)
            dragModel.SetNewSlot(slot);
        else
            helpManager.ShowDescription(slot);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (dragModel.IsMove)
            dragModel.RemoveNewSlot();
        else
            helpManager.HideDescription();
    }

    private void SelectItem()
    {
        Debug.Log(slot.Item);
        if (slot.Item == null)
            return;
        Debug.Log("-");
        helpManager.HideDescription();
        dragModel.SetMovableItem(slot.InventoryItem, slot);
    }

    public void ClearView()
    {
        image.sprite = null;//Old sprite slot
        itemCount.text = "";
    }

    public void ShowView(InventoryItem item)
    {
        image.sprite = item.Item.Icon;
        itemCount.text = item.CurrentSize.ToString();
    }

    public void UpdateCount(int value)
    {
        itemCount.text = value.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SelectItem();
    }
}
