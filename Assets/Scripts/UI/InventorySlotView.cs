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
    private InventoryController inventoryController => helpManager.InventoryController;
    private DragModel dragModel => helpManager.DragModel;

    void Awake()
    {
        Debug.Log("Awake");
        //slotButton.onClick.AddListener(SelectItem);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryController.SetCurrentSlot(slot);
        if (dragModel.IsMove)
            dragModel.SetNewSlot(slot);
        else
            helpManager.ShowDescription(slot);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventoryController.ResetCurrentSlot();
        if (dragModel.IsMove)
            dragModel.RemoveNewSlot();
        else
            helpManager.HideDescription();
    }

    private void SelectItem()
    {
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
        if (item == null)
        {
            ClearView();
            return;
        }
        image.sprite = item.Item.Icon;
        itemCount.text = item.CurrentSize.ToString();
    }

    public void UpdateCount(int value)
    {
        itemCount.text = value.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (slot.Item == null)
            return;
        if (eventData.button == PointerEventData.InputButton.Left)
            SelectItem();
        else if (eventData.button == PointerEventData.InputButton.Right)
            helpManager.ShowItemMenu();
    }
}
