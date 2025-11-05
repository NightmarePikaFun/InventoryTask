using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteractionView : MonoBehaviour
{
    [SerializeField]
    private Button useButton;
    [SerializeField]
    private Button destroyButton;
    [SerializeField]
    private RectTransform interactionTransform;
    [SerializeField]
    private CanvasGroup group;

    private HelpManager helpManager => HelpManager.Instance;
    private InventoryController inventoryController => helpManager.InventoryController;

    private void Awake()
    {
        useButton.onClick.AddListener(UseItem);
        destroyButton.onClick.AddListener(DestroyItem);
    }

    public void ShowView()
    {
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
        transform.position = new Vector3(inventoryController.slotTransform.position.x + interactionTransform.rect.width / 2 + 5, inventoryController.slotTransform.position.y);
    }

    public void HideView()
    {
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
    }

    private void UseItem()
    {
        inventoryController.UseItem();
        HideView();
    }

    private void DestroyItem()
    {
        inventoryController.RemoveItem();
        HideView();

    }
}
