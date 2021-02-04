using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public const string DROPED_ITEM_NAME = "Item";


    public static class Obj
    {
        public static GameObject GetUI()
        {
            const string TAG = "UI";
            GameObject foundObj = GameObject.FindGameObjectWithTag(TAG);

            INFORM_NOT_FOUND(foundObj, TAG);

            return foundObj;
        }

        public static GameObject GetBagSlot()
        {
            const string TAG = "BagSlot";
            GameObject foundObj = GameObject.FindGameObjectWithTag(TAG);

            INFORM_NOT_FOUND(foundObj, TAG);

            return foundObj;
        }

        public static GameObject GetInventoryContainer()
        {
            const string TAG = "InventoryContainer";
            GameObject foundObj = GameObject.FindGameObjectWithTag(TAG);

            INFORM_NOT_FOUND(foundObj, TAG);

            return foundObj;
        }
    }
    
    public static class Component
    {
        public static BagItemObject GetPlayerBag()
        {
            return (BagItemObject)Obj.GetBagSlot().GetComponent<ItemCell>().item;
        }

        public static EventDataBase GetEventDataBase()
        {
            const string TAG = "EventSystem";
            EventDataBase foundCmp = GameObject.FindGameObjectWithTag(TAG).GetComponent<EventDataBase>();
            
            INFORM_NOT_FOUND(foundCmp, TAG);

            return foundCmp;
        }

        public static InventoryController GetInventoryController()
        {
            const string TAG = "Inventory";
            InventoryController foundCmp = GameObject.FindGameObjectWithTag(TAG).GetComponent<InventoryController>();
            
            INFORM_NOT_FOUND(foundCmp, TAG);

            return foundCmp;
        }

        public static InventoryRender GetInventoryRender()
        {
            const string TAG = "Inventory";
            InventoryRender foundCmp = GameObject.FindGameObjectWithTag(TAG).GetComponent<InventoryRender>();
            
            INFORM_NOT_FOUND(foundCmp, TAG);

            return foundCmp;
        }

        public static CollisionCounter GetCollisionCounter()
        {
            const string TAG = "CollisionCounter";
            CollisionCounter foundCmp = GameObject.FindGameObjectWithTag(TAG).GetComponent<CollisionCounter>();
            
            INFORM_NOT_FOUND(foundCmp, TAG);

            return foundCmp;
        }

        public static PlayerMovement GetPlayerMovment()
        {
            const string TAG = "Player";
            PlayerMovement foundCmp = GameObject.FindGameObjectWithTag(TAG).GetComponent<PlayerMovement>();
            
            INFORM_NOT_FOUND(foundCmp, TAG);

            return foundCmp;
        }

    }

    public static class Inventory
    {
        public const string SLOT_ITEM_SPRITE = "ItemSprite";
    }

    static void INFORM_NOT_FOUND(Object obj, string tag)
    {
        if (obj == null)
        {
            Debug.LogError(tag + " NOT FOUND");
        }
    }
}


public static class Find
{
    public static T FindChildByTag<T>(this GameObject parent, string tag) where T:Component
    {
        Transform t = parent.transform;
        foreach(Transform tr in t)
        {
            if(tr.tag == tag)
            {
                return tr.GetComponent<T>();
            }
        }
        return null;
    }
}