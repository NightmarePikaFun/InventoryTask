using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragItem : MonoBehaviour
{
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private TMP_Text itemCount;

    private Camera camera;
    private bool canMove = false;

    private void Awake()
    {
        camera = Camera.main;
    }

    public void ActivateObject(InventoryItem item)
    {
        Debug.Log("++");
        canMove = true;
        itemIcon.sprite = item.Item.Icon;
    }

    public void DeactivateObject()
    {
        canMove = false;
    }

    void Update()
    {
        if(canMove)
        {
            transform.position = Input.mousePosition;// camera.WorldToScreenPoint(Input.mousePosition);
            Debug.Log(Input.mousePosition);
        }
    }
}