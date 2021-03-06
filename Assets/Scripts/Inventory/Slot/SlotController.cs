using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotController : MonoBehaviour, IDropHandler
{
                        EventDataBase eventDataBase;

    [SerializeField]    int slotID = 0;
                        
                        Image itemSprite = null;
                        ItemCell cell = null;
    [SerializeField]    ItemType itemType = ItemType.None;
    [SerializeField]    ItemType containerItemType = ItemType.None;

    void Awake()
    {
        eventDataBase = Global.Component.GetEventDataBase();

        itemSprite = Find.FindChildByTag<Image>(this.gameObject, Global.Inventory.SLOT_ITEM_SPRITE);
        cell = GetComponent<ItemCell>();

        TryActivateItemSprite();
    }

    // @IDropHandler
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject _otherSlotGo = eventData.pointerDrag.gameObject.GetComponent<PerentReference>().perent;
            SlotController _otherSlotController = _otherSlotGo.GetComponent<SlotController>();
            ItemObject _otherItem = _otherSlotGo.GetComponent<ItemCell>().item;
            
            if (cell.item == null)
            {
                if (IsSameTypeForSlots(_otherItem, this.itemType))
                {
                    cell.item = _otherItem;
                    cell.item.inventoryData.SetSlotID(slotID);
                    TryActivateItemSprite();

                    _otherSlotController.RemoveItem();
                }
            }
            else
            {
                if (IsSameTypeForSlots(_otherItem, this.itemType) && IsSameTypeForSlots(cell.item, _otherSlotController.GetItemType()))
                {
                    /*  swap items  */
                    ItemObject _item = cell.item;
                    cell.item = _otherItem;
                    _otherSlotGo.GetComponent<ItemCell>().item = _item;

                    /*   set slot id   */
                    cell.item.inventoryData.SetSlotID(slotID);
                    _otherSlotGo.GetComponent<ItemCell>().item.inventoryData.SetSlotID(_otherSlotController.GetSlotID());

                    /*   refresh slot spries   */
                    TryActivateItemSprite();
                    _otherSlotController.TryActivateItemSprite();

                }
            }

            EventSubstitude eventSubstitude = new EventSubstitude();
            eventSubstitude.InvokeDressEvent(itemType, true, cell.item);
        }
    }

    public void SetItem(ItemObject item)
    {
        cell.item = item;
        itemSprite.enabled = true;
        itemSprite.sprite = item.itemSprite;
    }

    void TryActivateItemSprite()
    {
        if (cell.item != null)
        {
            itemSprite.enabled = true;
            itemSprite.sprite = cell.item.itemSprite;
        }
        else
        {
            itemSprite.sprite = null;
            itemSprite.enabled = false;
        }
    }

    public void RemoveItem()
    {
        cell.item = null;
        itemSprite.sprite = null;
        itemSprite.enabled = false;
    }

    bool IsSameTypeForSlots(ItemObject item, ItemType itemType)
    {
        return itemType == ItemType.None || ((itemType != ItemType.None) && item.GetItemType() == itemType);
    }

    #region get set

    public void SetSlotID(int id)
    {
        this.slotID = id;
    }

    public int GetSlotID()
    {
        return this.slotID;
    }

    public ItemType GetItemType()
    {
        return this.itemType;
    }

    public void SetItemType(ItemType itemType)
    {
        this.itemType = itemType;
    }

    public void SetContainerItemType(ItemType itemType)
    {
        this.containerItemType = itemType;
    }

    public ItemType GetContainerItemType()
    {
        return this.containerItemType;
    }

    #endregion
}
