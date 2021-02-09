using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentItemObject", menuName = "Item/EquipmentItemObject")]
public class EquipmentItemObject : ItemObject
{

    [SerializeField]    SlotData slotData = null;
    [SerializeField]    List<ItemObject> innerItems = null;






    void Awake() 
    {
        base.Init(ItemType.Equipment);
    }

    public int GetSlotCount()
    {
        return slotData.GetAmountOfSlots();
    }

    #region get set

    public SlotData GetSlotData()
    {
        return this.slotData;
    }

    #endregion

    #region  IItemList

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
        if (IsFull() == false)
        {
            innerItems.Add(item);
        }
        else
        {
            Debug.LogWarning("CANT ADD ITEM INTO EQUIPMENT");
        }
    }

    public override int Count => innerItems.Count;

    public override void Clear()
    {
        this.innerItems.Clear();
    }

    #endregion
}
