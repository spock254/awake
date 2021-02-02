using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public Vector2Int size;
    public Sprite inventorySprite;
    Slot[] occupatedSlots;

    public void Init()
    {
        occupatedSlots = new Slot[size.x * size.y];
    }

    public Slot[] GetOccupatedSlots()
    {
        return occupatedSlots;
    }
}
