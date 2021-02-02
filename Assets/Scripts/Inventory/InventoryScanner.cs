using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScanner
{
    GameObject container = null;
    Slot[] slots = null;

    public InventoryScanner(GameObject container, int slotCount)
    {
        this.container = container;
        
        slots = new Slot[slotCount];
        int i = 0;
        foreach (Transform child in container.transform)
        {
            Slot slot = child.GetComponent<Slot>();
            if (slot != null)
            {
                slots[i] = slot;
                i++;
            }
        }
    }

    public Slot[] GetFreeSlots(ItemObject item)
    {
        // TODO 
        return  new Slot[] { slots[0] };
    }
}
