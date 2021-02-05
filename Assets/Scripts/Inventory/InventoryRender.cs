using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRender : MonoBehaviour
{
                        BagItemObject bag;
                        EventDataBase eventDataBase;
    
    [SerializeField]    GameObject slotPref = null;
                        GameObject container = null;

                        RectTransform inventoryRt;
                        RectTransform containerRt;
                        
                        Vector2 slotSize = Vector2.zero;

    void Awake()
    {
        inventoryRt = GetComponent<RectTransform>();
        containerRt = this.GetComponentInChildren<RectTransform>();
        container = this.transform.GetChild(0).gameObject;//Global.Obj.GetInventoryContainer(); 
        slotSize = container.GetComponent<GridLayoutGroup>().cellSize;
        eventDataBase = Global.Component.GetEventDataBase();
    }

    void Start() 
    {
        //! инит сумки с самого начала
        eventDataBase.OnOpenBag.AddListener(OnOpenBag_InitBag);
        eventDataBase.OnOpenBag.AddListener(OnOpenBag_EnableContainer);
        eventDataBase.OnOpenBag.AddListener(OnOpenBag_ResizeWindow);
        eventDataBase.OnOpenBag.AddListener(OnOpenBag_CreateSlots);    
        eventDataBase.OnOpenBag.AddListener(OnOpenBag_LocateItems);

        eventDataBase.OnCloseBag.AddListener(OnCloseBag_DestroySlots);
        eventDataBase.OnCloseBag.AddListener(OnCloseBag_DisableContainer);
        eventDataBase.OnCloseBag.AddListener(OnCloseBag_DeinitBag);
    }

    void Update()
    {
        
    }

    #region OnOpenBag event
    
    void OnOpenBag_InitBag(BagItemObject bag)
    {
        this.bag = bag;
    }

    void OnOpenBag_EnableContainer(BagItemObject bag)
    {
        container.SetActive(true);
        bag = null;
    }

    void OnOpenBag_ResizeWindow(BagItemObject bag)
    {
        ResizeWindow();
        bag = null;
    }
    
    void OnOpenBag_CreateSlots(BagItemObject bag)
    {
        CreateSlots();
        bag = null;
    }

    void OnOpenBag_LocateItems(BagItemObject bag)
    {
        LocateItems();
        bag = null;
    }

    #endregion
    #region OnOpenBag wrapper

    void LocateItems()
    {
        int _slotCount = bag.GetSlotCount();
        int _bagSize = bag.GetInnerItems().Count;
        
        List<ItemObject> items = bag.GetInnerItems();
        List<GameObject> _slots = GetSlots();

        if (bag.IsEmpty() == true)
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

    void ResizeWindow()
    {
        int _width = bag.GetBagSize().x * ((int)slotSize.x);
        int _height = bag.GetBagSize().y * ((int)slotSize.y);

        Vector2 _adaptedSize = new Vector2(_width, _height);

        inventoryRt.sizeDelta = containerRt.sizeDelta = _adaptedSize;
    }

    void CreateSlots()
    {
        for (int i = 0; i < bag.GetSlotCount(); i++)
        {
            GameObject _slotIns = Instantiate(slotPref, container.transform);
            _slotIns.GetComponent<SlotController>().SetSlotID(i);
        }
    }

    #endregion

    #region OnCloseBag event

    void OnCloseBag_DestroySlots()
    {
        foreach (Transform slot in container.transform)
        {
            Destroy(slot.gameObject);
        }
    }

    void OnCloseBag_DisableContainer()
    {
        container.SetActive(false);
    }

    void OnCloseBag_DeinitBag()
    {
        this.bag = null;
    }

    #endregion

    public void AddItem(ItemObject item)
    {
        SlotController _freeSlot = GetFreeSlot().GetComponent<SlotController>();
        int _slotID = _freeSlot.GetSlotID();
        
        item.inventoryData.SetSlotID(_slotID);
        _freeSlot.SetItem(item);
    }

    public int GetFreeSlotID(BagItemObject container)
    {
        List<ItemObject> _items = container.GetInnerItems();
        List<int> IDs = new List<int>();
        if (container.IsFuLL())
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
}
