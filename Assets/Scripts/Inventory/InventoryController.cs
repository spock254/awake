using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
                        EventDataBase eventDataBase;
                        InventoryRender inventoryRender;
    [SerializeField]    BagItemObject bag;   // TODO

    void Awake() 
    {
        eventDataBase = Global.Component.GetEventDataBase();
        inventoryRender = GetComponent<InventoryRender>();
    }
    // Start is called before the first frame update
    void Start()
    {
        eventDataBase.OnItemAdd.AddListener(OnItemAdd_AddItem);
    }

    void OnItemAdd_AddItem(ItemObject item)
    {
        bag.TryAddItem(item);
        // TODO найти куда засунуть и візвать рендер

        
    }
}

