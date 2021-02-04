using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotController : MonoBehaviour, IDropHandler
{
    public int slotID = 0;
    Image itemSprite = null;
    ItemCell cell = null;
    // Start is called before the first frame update
    void Awake()
    {
        itemSprite = Find.FindChildByTag<Image>(this.gameObject, Global.Inventory.SLOT_ITEM_SPRITE);
        cell = GetComponent<ItemCell>();

        TryActivateItemSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // @IDropHandler
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (cell.item == null)
            {
                GameObject _otherSlotGo = eventData.pointerDrag.gameObject.GetComponent<PerentReference>().perent;
                SlotController _otherSlotController = _otherSlotGo.GetComponent<SlotController>();
                ItemObject item = _otherSlotGo.GetComponent<ItemCell>().item;

                cell.item = item;

                TryActivateItemSprite();

                _otherSlotController.RemoveItem();
            }
        }
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
}
