using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public const string DROPED_ITEM_NAME = "Item";


    public static class Obj
    {
        public static GameObject GetSlotContainer()
        {
            const string TAG = "SlotContainer";
            GameObject foundObj = GameObject.FindGameObjectWithTag(TAG);

            INFORM_NOT_FOUND(foundObj, TAG);

            return foundObj;
        }

    }
    
    public static class Component
    {
        public static EventDataBase GetEventDataBase()
        {
            const string TAG = "EventSystem";
            EventDataBase foundCmp = GameObject.FindGameObjectWithTag(TAG).GetComponent<EventDataBase>();
            
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

    static void INFORM_NOT_FOUND(Object obj, string tag)
    {
        if (obj == null)
        {
            Debug.LogError(tag + " NOT FOUND");
        }
    }
}
