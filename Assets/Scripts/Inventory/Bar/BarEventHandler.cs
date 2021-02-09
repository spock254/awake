using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarEventHandler : MonoBehaviour, IRender
{
                        EquipmentItemObject equipment;
    [SerializeField]    GameObject slotPref;

                        EventDataBase eventDataBase;
                        GameObject container = null;
                        GridLayoutGroup containerGrid = null;

                        RectTransform barRt = null;
                        RectTransform containerRt = null;

    void Awake() 
    {
        eventDataBase = Global.Component.GetEventDataBase();
        container = this.transform.GetChild(0).gameObject;
        containerGrid = container.GetComponent<GridLayoutGroup>();

        barRt = this.GetComponent<RectTransform>();
        containerRt = container.GetComponent<RectTransform>();
    }

    void Start() 
    {

        eventDataBase.OnDressOnEquipment.AddListener(OnDressOnEquipment_InitEquipment);
        eventDataBase.OnDressOnEquipment.AddListener(OnDressOnEquipment_EnableContainer);
        eventDataBase.OnDressOnEquipment.AddListener(OnDressOnEquipment_ResizeWindow);
        eventDataBase.OnDressOnEquipment.AddListener(OnDressOnEquipment_CreateSlots);
        eventDataBase.OnDressOnEquipment.AddListener(OnDressOnEquipment_LocateItems);   
    
        eventDataBase.OnDressOffEquipment.AddListener(OnDressOffEquipment_DestroySlots);
        eventDataBase.OnDressOffEquipment.AddListener(OnDressOffEquipment_DisableContainer);
        eventDataBase.OnDressOffEquipment.AddListener(OnDressOffEquipment_DeinitEquipment);
    }

    #region OnDressOnEquipment wrapper
    
    void OnDressOnEquipment_InitEquipment(EquipmentItemObject equipment)
    {
        InitEquipment(equipment);
    }

    void OnDressOnEquipment_EnableContainer(EquipmentItemObject equipment)
    {
        EnableContainer();
        equipment = null;
    }

    void OnDressOnEquipment_ResizeWindow(EquipmentItemObject equipment)
    {
        ResizeWindow();
        equipment = null;
    }

    void OnDressOnEquipment_CreateSlots(EquipmentItemObject equipment)
    {
        CreateSlots();
        equipment = null;
    }

    void OnDressOnEquipment_LocateItems(EquipmentItemObject equipment)
    {
        LocateItems();
        equipment = null;
    }

    #endregion
    #region OnDressOnEquipment event

    void InitEquipment(EquipmentItemObject equipment)
    {
        this.equipment = equipment;
    }

    void EnableContainer()
    {
        container.SetActive(true);
    }

    void ResizeWindow()
    {
        int _amountOfSlots = equipment.GetSlotData().GetAmountOfSlots();
        Vector2 _adaptedSize = new Vector2(_amountOfSlots * containerGrid.cellSize.x, containerGrid.cellSize.y);

        barRt.sizeDelta = containerRt.sizeDelta = _adaptedSize;
    }

    void CreateSlots()
    {
        int _amountOfSlots = equipment.GetSlotData().GetAmountOfSlots();

        for (int i = 0; i < _amountOfSlots; i++)
        {
            GameObject _slotIns = Instantiate(slotPref, container.transform);
            _slotIns.GetComponent<SlotController>().SetSlotID(i); 
        }    
    }

    void LocateItems()
    {
        int _slotCount = equipment.GetSlotCount();
        int _bagSize = equipment.GetInnerItems().Count;
        
        List<ItemObject> items = equipment.GetInnerItems();
        List<GameObject> _slots = GetSlots();

        if (equipment.IsEmpty() == true)
        {
            return;   
        }

        for (int i = 0; i < _slotCount; i++)
        {
            for (int j = 0; j < _bagSize; j++)
            {
                int _itemSlotID = items[j].inventoryData.GetSlotID();
                int _slotID = _slots[i].GetComponent<SlotController>().GetSlotID();
                
                if (_itemSlotID == _slotID)
                {
                    _slots[_slotID].GetComponent<SlotController>().SetItem(items[j]);
                    continue;
                }
            }
        }
    }


    #endregion
    #region OnDressOffEquipment

    void OnDressOffEquipment_DestroySlots()
    {
        foreach (Transform slot in container.transform)
        {
            Destroy(slot.gameObject);
        }
    }

    void OnDressOffEquipment_DisableContainer()
    {
        container.SetActive(false);
    }

    void OnDressOffEquipment_DeinitEquipment()
    {
         this.equipment = null;
    }

    #endregion

    public void Add(ItemObject item)
    {
        SlotController _freeSlot = GetFreeSlot().GetComponent<SlotController>();
        int _slotID = _freeSlot.GetSlotID();
        
        item.inventoryData.SetSlotID(_slotID);
        _freeSlot.SetItem(item);
    }

    GameObject GetFreeSlot()
    {
        foreach (Transform slot in container.transform)
        {
            if (slot.GetComponent<ItemCell>().item == null)
            {
                return slot.gameObject;        
            }
        }

        return null;
    }

    public int GetFreeSlotID(ItemObject container)
    {
        List<ItemObject> _items = container.GetInnerItems();
        List<int> IDs = new List<int>();

        if (container.IsFull())
        {
            return -1;
        }

        if (container.IsEmpty())
        {
            return 0;
        }

        for (int i = 0; i < _items.Count; i++)
        {
            IDs.Add(_items[i].inventoryData.GetSlotID());
        }

        for (int i = 0; i < _items.Count; i++)
        {
            if (IDs.Contains(i) == false)
            {
                return i;
            }
        }

        return _items.Count;
    }

    List<GameObject> GetSlots()
    {
        List<GameObject> _slots = new List<GameObject>();

        foreach (Transform slot in container.transform)
        {
            _slots.Add(slot.gameObject);
        }

        return _slots;
    }
}
