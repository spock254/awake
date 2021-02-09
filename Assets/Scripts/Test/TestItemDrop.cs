using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ItemObject bag = Global.Component.GetPlayerBag();

            if (bag == null)
            {
                Debug.Log("BAG NOT FOUND");
                return;
            }
            
            if (inventory.IsOpen(inventory.transform.GetChild(0).gameObject) == false)
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
                if (hit.collider.name.StartsWith(Global.DROPED_ITEM_NAME)) 
                {
                    ItemObject item = hit.collider.gameObject.GetComponent<ItemCell>().item;

                    eventDataBase.OnAddItem.Invoke(Instantiate<ItemObject>(item));

                    Destroy(hit.collider.gameObject);
                    return;
                }
            }
        }

        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     ItemObject equipment = Global.Obj.GetEquipmentSlot().GetComponent<ItemCell>().item;
        //     eventDataBase.OnDressOnEquipment.Invoke((EquipmentItemObject)equipment);
        // }
    }

    private void OnApplicationQuit() 
    {
        BagItemObject bag = Global.Component.GetPlayerBag();
        if (bag != null)
        {
            bag.Clear();
        }
        EquipmentItemObject equipment = (EquipmentItemObject)Global.Obj.GetEquipmentSlot().GetComponent<ItemCell>().item;

        if (equipment != null)
        {
            equipment.Clear();
        }
    }
}
