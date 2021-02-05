using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryController : MonoBehaviour
{
                        EventDataBase eventDataBase = null;
                        InventoryRender inventoryRender = null;
    [SerializeField]    bool isPlayerInventory = true;
    
    [Header("если не инвунтарь игрока заинитить!")]
    [SerializeField]    BagItemObject bag = null;

                        GameObject container;

    void Awake() 
    {
        eventDataBase = Global.Component.GetEventDataBase();
        inventoryRender = GetComponent<InventoryRender>();
        container = this.transform.GetChild(0).gameObject;//Global.Obj.GetInventoryContainer();
    }

    void Start() 
    {
        eventDataBase.OnAddItem.AddListener(OnAddItem_AddItem);
    }

    void OnAddItem_AddItem(ItemObject item)
    {
        BagItemObject _container = (isPlayerInventory == true) ? Global.Component.GetPlayerBag() : bag;

        if (_container != null)
        {
            if (_container.IsFuLL() == false)
            {

                if (IsOpen() == true)
                {
                    _container.AddItem(item);
                    inventoryRender.AddItem(item);
                }
                else
                {
                    item.inventoryData.SetSlotID(inventoryRender.GetFreeSlotID(_container));
                    _container.AddItem(item);
                }
            }
        }
    }

    public bool IsOpen()
    {
        return container.activeInHierarchy == true;
    }

    public void Open()
    {
        container.SetActive(true);
    }

    public void Close()
    {
        container.SetActive(false);
    }
}

