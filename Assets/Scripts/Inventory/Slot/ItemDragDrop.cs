using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    Image itemSprite = null;
    Canvas uiCanvas = null;
    RectTransform rt = null;
    Vector2 originPosition = Vector2.zero;
    CanvasGroup itemSpriteCanvasGroup = null;

    void Awake() 
    {
        uiCanvas = Global.Obj.GetUI().GetComponent<Canvas>();
        rt = GetComponent<RectTransform>();
        itemSprite = GetComponent<Image>();  
        itemSpriteCanvasGroup = GetComponent<CanvasGroup>();  

        originPosition = rt.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        //Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemSpriteCanvasGroup.blocksRaycasts = false;
        //Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rt.anchoredPosition += eventData.delta / uiCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject _inventory = Global.Obj.GetInventory();
        InventoryController _inventoryController = _inventory.GetComponent<InventoryController>();
        GameObject _slot = eventData.pointerDrag.GetComponent<PerentReference>().perent;
        ItemObject _item = _slot.GetComponent<ItemCell>().item;
        SlotController _slotController = _slot.GetComponent<SlotController>();
        
        if (IsPointerOverUIElement() == false)
        {

            _inventoryController.DropItem(_item);
            _slotController.RemoveItem();
        }

        EventSubstitude eventSubstitude = new EventSubstitude();
        eventSubstitude.InvokeDressEvent(_slotController.GetItemType(), false);

        itemSpriteCanvasGroup.blocksRaycasts = true;
        rt.anchoredPosition = originPosition;

    }

    public static bool IsPointerOverUIElement()
    {
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
