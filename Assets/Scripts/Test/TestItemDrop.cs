using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestItemDrop : MonoBehaviour
{
    public ItemObject item;
    public BagItemObject bag;
    EventDataBase eventDataBase;

    void Start() 
    {
        eventDataBase = Global.Component.GetEventDataBase();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            item.InstantiatePref(transform.position);
        }    

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            eventDataBase.OnBagOpen.Invoke(bag);
        }

        Vector3 mousePosRight = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePosRight.x, mousePosRight.y);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            foreach (var hit in hits)
            {
                //Debug.Log(hit.collider.name);
                if (hit.collider.name.Contains(Global.DROPED_ITEM_NAME)) 
                {
                    CommonItemObject common = (CommonItemObject)hit.collider.gameObject.GetComponent<ItemCell>().item;
                    //bag.TryAddItem(common);

                    eventDataBase.OnItemAdd.Invoke(common);
                }
            }
        }
    }
}
