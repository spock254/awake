using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { OnPlayerUse, Equipment, Сommon }

public abstract class ItemObject : ScriptableObject 
{
    public string itemID;// = System.Guid.NewGuid().ToString();
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public ItemType itemType;
    public GameObject itemPrefab;

    bool IsSameItem(ItemObject otherItem)
    {
        return itemID == otherItem.itemID;
    }
}
