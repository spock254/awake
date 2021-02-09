using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BagItemObject", menuName = "Item/BagItemObject")]
public class BagItemObject : ItemObject
{
    [SerializeField]    List<ItemObject> innerItems;
    [SerializeField]    Vector2Int bagSize;
                                        
    void Awake() 
    {
        base.Init(ItemType.Bag);
    }

    // public bool AddItem(ItemObject item)
    // {
    //     innerItems.Add(item);
    //     return true;
    // }

    public int GetSlotCount()
    {
        return bagSize.x * bagSize.y;
    }


    #region get set

    public Vector2Int GetBagSize()
    {
        return bagSize;
    }

    #endregion

    #region IItemList
    
    public override bool IsFull()
    {
        return innerItems.Count == GetSlotCount();
    }

    public override bool IsEmpty()
    {
        return innerItems.Count == 0;
    }

    public override List<ItemObject> GetInnerItems()
    {
        return this.innerItems;
    }

    public override void Add(ItemObject item)
    {
        innerItems.Add(item);
    }

    public override int Count => innerItems.Count;
    
    public override void Clear()
    {
        this.innerItems.Clear();
    }
    #endregion

}
