using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
    [SerializeField]
    public InventorySlot SlotPrefab;

    public static HelpManager Instance;
    
    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnPrefab(GameObject spawnObject, Transform parent)
    {
        return Instantiate(spawnObject, parent);
    }

    public InventorySlot SpawnPrefab(InventorySlot slot, Transform parent)
    {
        return Instantiate(slot, parent);
    }
}
