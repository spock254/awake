using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentItemObject", menuName = "Item/EquipmentItemObject")]
public class EquipmentItemObject : ItemObject
{
    void Awake() 
    {
        base.Init(ItemType.Equipment);
    }
}
