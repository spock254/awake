using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarRender : MonoBehaviour
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
        
    }


    #endregion
}
