using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDataBase : MonoBehaviour
{
    [HideInInspector]   public UnityEvent<ItemObject> OnItemAdd;

    void Awake() 
    {
        OnItemAdd = new UnityEvent<ItemObject>();    
    }
}
