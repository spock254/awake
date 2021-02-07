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

    public void AddItem(ItemObject item)
    {
        if (slotData.GetAmountOfSlots() < innerItems.Count)
        {
            innerItems.Add(item);
        }
        else
        {
            Debug.LogWarning("CANT ADD ITEM INTO EQUIPMENT");
        }
    }

    #region get set

    public List<ItemObject> GetInnerItems()
    {
        return this.innerItems;
    }

    public SlotData GetSlotData()
    {
        return this.slotData;
    }

    #endregion
}
