using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { OnPlayerUse, Equipment, Common, Bag }

public abstract class ItemObject : ScriptableObject 
{
    [HideInInspector]   public string ID;
                        public int itemWeight;
                        public string itemName;
                        public string itemDescription;
                        public Sprite itemSprite;
    [HideInInspector]   public ItemType itemType;
                        public GameObject itemPrefab;

                        public InventoryData inventoryData;

    protected void Init(ItemType itemType)
    {
        this.itemType = itemType;
        this.ID = System.Guid.NewGuid().ToString();

        inventoryData.Init();
    }

    bool IsSameItem(ItemObject otherItem)
    {
        return ID == otherItem.ID;
    }

    public void InstantiatePref(Vector3 pos)
    {
        GameObject _itemPref = GameObject.Instantiate(itemPrefab, pos, Quaternion.identity);
        ItemObject _item = GameObject.Instantiate(this);

        _itemPref.GetComponent<SpriteRenderer>().sprite = _item.itemSprite;
        _itemPref.GetComponent<ItemCell>().item = _item;
    }

    #region operator == !=
    public static bool operator ==(ItemObject item1, ItemObject item2)
    {
        return item1.ID == item2.ID;
    }

    public static bool operator !=(ItemObject item1, ItemObject item2)
    {
        return item1.ID != item2.ID;
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    #endregion
}
