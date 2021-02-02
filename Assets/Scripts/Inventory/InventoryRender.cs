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

    //[SerializeField]    BagItemObject bag;  // TODO загружать динамически

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

        InitInventory();
    }

    void Start() 
    {
        eventDataBase.OnItemAdd.AddListener(OnItemAdd_AddItem);

        // !сначало подписать сканер потом все остольное
        eventDataBase.OnBagOpen.AddListener(OnBagOpen_InitScanner);
        eventDataBase.OnBagOpen.AddListener(OnBagOpen_CreateSlots);
    }

    void OnBagOpen_InitScanner(BagItemObject bag)
    {
        Debug.Log(bag.GetSlotCount());
        scanner = new InventoryScanner(slotContainer, bag.GetSlotCount());
    }
    
    void OnBagOpen_CreateSlots(BagItemObject bag)
    {
        int _slotCount = bag.GetSlotCount();

        if (_slotCount == GetSlotCount())
        {
            return;
        }
        else
        {
            //  если разное количество слотов, удаляю все старые потом создаю новые
            foreach(Transform child in slotContainer.transform)
            {
                Destroy(child);
            }
            
            for (int i = 0; i < _slotCount; i++)
            {
                GameObject slotPrefInst = Instantiate(slotPref, slotContainer.transform);
                Slot slot = slotPrefInst.GetComponent<Slot>();
                slot.SetSlotID(i);
            }
        }

    }

    void InitInventory()
    {

    }

    void OnItemAdd_AddItem(ItemObject item)
    {
        Slot[] slots = scanner.GetFreeSlots(item);

        /* если нет места в сумке или нет места для айтема */
        if (slots == null)
        {
            //TODO
            return;
        }

        foreach (var slot in slots)
        {
            slot.SetIsOccupied(true);
        }

        GameObject imgItemInst = Instantiate(imgItemPref, itemContainer.transform);
        imgItemInst.GetComponent<RectTransform>().anchoredPosition = slots[0].GetComponent<RectTransform>().anchoredPosition;
        imgItemInst.GetComponent<Image>().sprite = item.inventoryData.inventorySprite;
    }

    int GetSlotCount()
    {
        int i = 0;
        
        foreach(Transform child in slotContainer.transform)
        {
            i++;
        }

        return i;
    }
}
