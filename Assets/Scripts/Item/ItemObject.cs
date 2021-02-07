using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public abstract class ItemObject : ScriptableObject 
{
    [HideInInspector]   public string ID;
                        public string itemName;
                        public string itemDescription;
                        public Sprite itemSprite;
                        ItemType itemType;
                        public GameObject itemPrefab;

                        public InventoryData inventoryData;

    protected void Init(ItemType itemType)
    {
        this.itemType = itemType;
        this.ID = System.Guid.NewGuid().ToString();

        //inventoryData.Init();
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

    #region get set

    public ItemType GetItemType()
    {
        return this.itemType;
    }

    #endregion 
}
