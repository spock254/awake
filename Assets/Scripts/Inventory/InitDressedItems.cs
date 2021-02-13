using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDressedItems : MonoBehaviour
{
    [SerializeField]    ItemCell equiepment;
                        EventDataBase eventDataBase;

    void Awake() 
    {
        eventDataBase = Global.Component.GetEventDataBase();
    }

    void Start() 
    {
        if (equiepment.item != null)
        {
            eventDataBase.OnDressOnEquipment.Invoke((EquipmentItemObject) equiepment.item);
        }    
    }
}
