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

    [HideInInspector]   public UnityEvent<EquipmentItemObject> OnDressOnEquipment;
    [HideInInspector]   public UnityEvent OnDressOffEquipment;

    [HideInInspector]   public UnityEvent<EquipmentItemObject> OnDressOnBag;
    [HideInInspector]   public UnityEvent OnDressOffBag;

    void Awake() 
    {
        OnAddItem = new UnityEvent<ItemObject>();    
        OnOpenBag = new UnityEvent<BagItemObject>();
        OnCloseBag = new UnityEvent();

        OnDressOnEquipment = new UnityEvent<EquipmentItemObject>();
        OnDressOffEquipment = new UnityEvent();

        OnDressOnBag = new UnityEvent<EquipmentItemObject>();
        OnDressOffBag = new UnityEvent();
    }
}
