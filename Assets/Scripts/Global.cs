﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public const string DROPED_ITEM_NAME = "__Item__";


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

        public static GameObject GetEquipmentSlot()
        {
            const string TAG = "EquipmentSlot";
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

        public static GameObject GetPlayer()
        {
            const string TAG = "Player";
            GameObject foundObj = GameObject.FindGameObjectWithTag(TAG);

            INFORM_NOT_FOUND(foundObj, TAG);

            return foundObj;
        }

        public static GameObject GetInventory()
        {
            const string TAG = "Inventory";
            GameObject foundObj = GameObject.FindGameObjectWithTag(TAG);

            INFORM_NOT_FOUND(foundObj, TAG);

            return foundObj;
        }

        public static GameObject GetBar()
        {
            const string TAG = "Bar";
            GameObject foundObj = GameObject.FindGameObjectWithTag(TAG);

            INFORM_NOT_FOUND(foundObj, TAG);

            return foundObj;
        }

        public static GameObject GetBarContainer()
        {
            const string TAG = "BarContainer";
            GameObject foundObj = GameObject.FindGameObjectWithTag(TAG);

            INFORM_NOT_FOUND(foundObj, TAG);

            return foundObj;
        }

        public static GameObject GetInventoryManager()
        {
            const string TAG = "InventoryManager";
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
            const string TAG = "InventoryManager";
            InventoryController foundCmp = GameObject.FindGameObjectWithTag(TAG).GetComponent<InventoryController>();
            
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

        public static BagEventHandler GetBagEventHandler()
        {
            const string TAG = "Inventory";
            BagEventHandler foundCmp = GameObject.FindGameObjectWithTag(TAG).GetComponent<BagEventHandler>();
            
            INFORM_NOT_FOUND(foundCmp, TAG);

            return foundCmp;
        }

        public static BarEventHandler GetBarEventHandler()
        {
            const string TAG = "Bar";
            BarEventHandler foundCmp = GameObject.FindGameObjectWithTag(TAG).GetComponent<BarEventHandler>();
            
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