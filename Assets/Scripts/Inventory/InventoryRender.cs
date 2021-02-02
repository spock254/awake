using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRender : MonoBehaviour
{
                        InventoryScanner scanner;
                        EventDataBase eventDataBase;

    [SerializeField]    GameObject slotContainer;   /* контейнер для пустых ячеек */
    [SerializeField]    GameObject itemContainer;   /* контейнер для иконое айтемов */

    [SerializeField]    BagItemObject bag;  // TODO загружать динамически

    [SerializeField]    GameObject slotPref;
    [SerializeField]    GameObject imgItemPref;

                        GridLayoutGroup grid;
                        RectTransform rt;
    
    void Awake() 
    {
        rt = GetComponent<RectTransform>();
        grid = slotContainer.GetComponent<GridLayoutGroup>();
        eventDataBase = Global.Component.GetEventDataBase();
        // TODO подогнать размер ячеек

        CreateSlots();
        
        scanner = new InventoryScanner(slotContainer, bag.GetSlotCount());
    }

    void Start() 
    {
        eventDataBase.OnItemAdd.AddListener(OnItemAdd_AddItem);   
    }

    void CreateSlots()
    {
        int _slotCount = bag.GetSlotCount();

        for (int i = 0; i < _slotCount; i++)
        {
            GameObject slotPrefInst = Instantiate(slotPref, slotContainer.transform);
            Slot slot = slotPrefInst.GetComponent<Slot>();
            slot.SetSlotID(i);
        }
    }

    void OnItemAdd_AddItem(ItemObject item)
    {
        Slot[] slots = scanner.GetFreeSlots(item);

        foreach (var slot in slots)
        {
            slot.SetIsOccupied(true);
        }

        GameObject imgItemInst = Instantiate(imgItemPref, itemContainer.transform);
        imgItemInst.GetComponent<RectTransform>().anchoredPosition = slots[0].GetComponent<RectTransform>().anchoredPosition;
        //Debug.Log(slots[0].GetComponent<RectTransform>().anchoredPosition);
    }
}
