using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScanner
{
    GameObject container = null;
    Slot[] slots = null;

    private static InventoryScanner instance;

    public static InventoryScanner GetInstance()
    {
        return instance;
    }

    public InventoryScanner(GameObject container, int slotCount)
    {
        if (instance != null) { return; }

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

        instance = this;
    }

    public Slot[] GetFreeSlots(ItemObject item)
    {
        /* если айтем размером 1х1 */
        if (item.inventoryData.size == Vector2Int.one)
        {
            foreach (var slot in slots)
            {
                if (slot.IsOccupied() == false)
                {
                    return new Slot[] { slot }; 
                }       
            }
        }

        // TODO 
        return  null;
    }

    public bool HasFreeSpace(ItemObject item)
    {
        return GetFreeSlots(item) != null;
    }

    public int GetSlotCount()
    {
        return slots.Length;
    }
}
