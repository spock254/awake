using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public abstract class ItemObject : ScriptableObject, IItemList<ItemObject>
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

    #region IItemList

    public virtual bool IsEmpty()
    {
        throw new NotImplementedException();
    }

    public virtual bool IsFull()
    {
        throw new NotImplementedException();
    }

    public virtual List<ItemObject> GetInnerItems()
    {
        throw new NotImplementedException();
    }

    public virtual int Count => throw new NotImplementedException();

    public virtual bool IsReadOnly => throw new NotImplementedException();

    public virtual ItemObject this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public virtual int IndexOf(ItemObject item)
    {
        throw new NotImplementedException();
    }

    public virtual void Insert(int index, ItemObject item)
    {
        throw new NotImplementedException();
    }

    public virtual void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public virtual void Add(ItemObject item)
    {
        throw new NotImplementedException();
    }

    public virtual void Clear()
    {
        throw new NotImplementedException();
    }

    public virtual bool Contains(ItemObject item)
    {
        throw new NotImplementedException();
    }

    public virtual void CopyTo(ItemObject[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public virtual bool Remove(ItemObject item)
    {
        throw new NotImplementedException();
    }

    public virtual IEnumerator<ItemObject> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    #endregion
}
