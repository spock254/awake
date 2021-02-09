using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryController : MonoBehaviour
{
                        EventDataBase eventDataBase = null;
                        BagEventHandler bagEvent = null;

                        GameObject container;

    void Awake() 
    {
        eventDataBase = Global.Component.GetEventDataBase();
        bagEvent = GetComponent<BagEventHandler>();
        container = this.transform.GetChild(0).gameObject;//Global.Obj.GetInventoryContainer();
    }

    void Start() 
    {
        eventDataBase.OnAddItem.AddListener(OnAddItem_AddItem);
    }

    void OnAddItem_AddItem(ItemObject item)
    {
        //BagItemObject _container = Global.Component.GetPlayerBag();
        ContainerPack _containerPack = GetContainerPack();

        if (_containerPack == null)
        {
            //TODO все забито
            
        }

        IItemList<ItemObject> _innerItems = _containerPack.GetInnerItems();
        IRender _render = _containerPack.GetRender();
        GameObject _container = _containerPack.GetContainer();

        if (_innerItems != null)
        {
            //if (_container.IsFuLL() == false)
            //{

                if (IsOpen(_container) == true)
                {
                    _innerItems.Add(item);
                    _render.Add(item);
                }
                else
                {
                    item.inventoryData.SetSlotID(_render.GetFreeSlotID((ItemObject)_innerItems));
                    _innerItems.Add(item);
                }
            //}
        }
    }

    public void DropItem(ItemObject item)
    {
        BagItemObject _container = Global.Component.GetPlayerBag();
        _container.GetInnerItems().Remove(item);
        item.InstantiatePref(Global.Obj.GetPlayer().transform.position);
    }

    public bool IsOpen(GameObject container)
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

    ContainerPack GetContainerPack()
    {
        // TODO сначало рука
        GameObject _equipmentSlot = Global.Obj.GetEquipmentSlot();
        EquipmentItemObject _equipment = (EquipmentItemObject)_equipmentSlot.GetComponent<ItemCell>().item;
        
        if (_equipment != null && _equipment.IsFull() == false)
        {
            return new ContainerPack(_equipment, Global.Component.GetBarEventHandler(), Global.Obj.GetBar().transform.GetChild(0).gameObject);
        }
        else
        {
            GameObject _bagSlot = Global.Obj.GetBagSlot();
            BagItemObject _bag = (BagItemObject) _bagSlot.GetComponent<ItemCell>().item;

            if (_bag != null && _bag.IsFull() == false)
            {
                return new ContainerPack(_bag, Global.Component.GetBagEventHandler(), Global.Obj.GetInventory().transform.GetChild(0).gameObject);
            }
        }

        return null;
    }
}

public class ContainerPack
{
    IItemList<ItemObject> innerItems = null;
    IRender render = null;
    GameObject container = null;

    public ContainerPack(IItemList<ItemObject> innerItems, IRender render, GameObject container)
    {
        this.innerItems = innerItems;
        this.render = render;
        this.container = container;
    }
    
    #region get set
    public IItemList<ItemObject> GetInnerItems()
    {
        return this.innerItems;
    }

    public IRender GetRender()
    {
        return this.render;
    }

    public GameObject GetContainer()
    {
        return this.container;
    }

    #endregion
}
