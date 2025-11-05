using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour
{
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private TMP_Text itemCount;
    [SerializeField]
    private CanvasGroup group;

    private Camera camera;

    private bool canMove = false;
    public bool IsMove { get { return canMove; } private set { canMove = value; } }
    
    private DragModel dragModel => HelpManager.Instance.DragModel;

    private void Awake()
    {
        camera = Camera.main;
    }

    public void ActivateObject(InventoryItem item)
    {
        group.alpha = 1;
        canMove = true;
        itemIcon.sprite = item.Item.Icon;
        itemCount.text = item.CurrentSize.ToString();
    }

    public void Hide()
    {
        group.alpha = 0;
    }

    void Update()
    {
        if(canMove)
        {
            transform.position = Input.mousePosition;// camera.WorldToScreenPoint(Input.mousePosition);
            if (Input.GetMouseButtonUp(0))
            {
                canMove = false;
                dragModel.StoreItem();
            }
        }
    }
}