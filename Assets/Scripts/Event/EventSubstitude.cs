using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubstitude
{
    EventDataBase eventData;

    public EventSubstitude()
    {
        this.eventData = Global.Component.GetEventDataBase();
    }

    public void InvokeDressEvent(ItemType itemType, bool isOn, ItemObject item = null)
    {
        if (itemType == ItemType.Equipment && isOn == true)
        {
            eventData.OnDressOnEquipment.Invoke((EquipmentItemObject)item);
        }
        else if (itemType == ItemType.Equipment && isOn == false)
        {
            eventData.OnDressOffEquipment.Invoke();
        }
    }
}
