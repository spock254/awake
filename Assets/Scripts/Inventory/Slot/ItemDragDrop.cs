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
        itemSpriteCanvasGroup.blocksRaycasts = true;
        rt.anchoredPosition = originPosition;
        //Debug.Log("OnEndDrag");
    }

}
