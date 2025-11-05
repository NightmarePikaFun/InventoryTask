using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
    [SerializeField]
    public InventorySlot SlotPrefab;
    [SerializeField]
    private DescriptionView Description;
    [SerializeField]
    public DragModel DragModel;
    [SerializeField]
    private ItemInteractionView interactionView;

    public static HelpManager Instance;
    
    public InventoryController InventoryController;


    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
        InventoryController = new InventoryController();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            interactionView.HideView();
        }
    }

    public GameObject SpawnPrefab(GameObject spawnObject, Transform parent)
    {
        return Instantiate(spawnObject, parent);
    }

    public InventorySlot SpawnPrefab(InventorySlot slot, Transform parent)
    {
        return Instantiate(slot, parent);
    }

    public void ShowDescription(InventorySlot slot)
    {
        Description.Show(slot);
    }

    public void HideDescription()
    {
        Description.Hide();
    }

    public void ShowItemMenu()
    {
        interactionView.ShowView();
        Description.Hide();
    }

    public void UpdateInventoryView()
    {

    }
}
