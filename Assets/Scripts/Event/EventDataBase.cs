using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDataBase : MonoBehaviour
{
    /* inventory events */
    [HideInInspector]   public UnityEvent<ItemObject> OnAddItem;

    /* interaction events */
    [HideInInspector]   public UnityEvent<BagItemObject> OnOpenBag;
    [HideInInspector]   public UnityEvent OnCloseBag;

    void Awake() 
    {
        OnAddItem = new UnityEvent<ItemObject>();    
        OnOpenBag = new UnityEvent<BagItemObject>();
        OnCloseBag = new UnityEvent();
    }
}
