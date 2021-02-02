using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDataBase : MonoBehaviour
{
    /* inventory events */
    [HideInInspector]   public UnityEvent<ItemObject> OnItemAdd;

    /* interaction events */
    [HideInInspector]   public UnityEvent<BagItemObject> OnBagOpen;

    void Awake() 
    {
        OnItemAdd = new UnityEvent<ItemObject>();    
        OnBagOpen = new UnityEvent<BagItemObject>();
    }
}
