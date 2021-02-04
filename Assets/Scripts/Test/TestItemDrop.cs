using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestItemDrop : MonoBehaviour
{
    public ItemObject item;
    EventDataBase eventDataBase;
    InventoryController inventory;


    void Start() 
    {
        eventDataBase = Global.Component.GetEventDataBase();
        inventory = Global.Component.GetInventoryController();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            item.InstantiatePref(transform.position);
        }    

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ItemObject bag = Global.Component.GetPlayerBag();

            if (bag == null)
            {
                Debug.Log("BAG NOT FOUND");
                return;
            }
            
            if (inventory.IsOpen() == false)
            {
                eventDataBase.OnOpenBag.Invoke((BagItemObject)bag);
            }
            else
            {
                eventDataBase.OnCloseBag.Invoke();
            }

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
                    ItemObject common = hit.collider.gameObject.GetComponent<ItemCell>().item;
                    //bag.TryAddItem(common);
                    //InventoryController inventory = Global.Component.GetInventoryController();
                    //inventory.AddItem(common);
                    eventDataBase.OnAddItem.Invoke(Instantiate(common));
                }
            }
        }
    }
}
