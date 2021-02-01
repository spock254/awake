using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "СommonItemObject", menuName = "Item/СommonItemObject")]
public class CommonItemObject : ItemObject
{
    void Awake() 
    {
        base.Init(ItemType.Common);
    }
}
