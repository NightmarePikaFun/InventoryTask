using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private InventorySlot slot;
    [SerializeField]
    private Button slotButton;

    void Awake()
    {
        Debug.Log("Awake");
        //slotButton.onClick.AddListener(SelectItem);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HelpManager.Instance.ShowDescription(slot);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HelpManager.Instance.HideDescription();
    }

    private void SelectItem()
    {
        Debug.Log(slot.Item);
        if (slot.Item == null)
            return;
        Debug.Log("-");
        HelpManager.Instance.DragModel.SetMovableItem(slot.InventoryItem, slot);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SelectItem();
    }
}
