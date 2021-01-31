using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "СommonItemObject", menuName = "Item/СommonItemObject")]
public class СommonItemObject : ItemObject
{
    void Awake() 
    {
        base.itemType = ItemType.Сommon;
        base.itemID = System.Guid.NewGuid().ToString();
    }
}
