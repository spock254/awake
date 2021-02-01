using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OnPlayerUseItemObject", menuName = "Item/OnPlayerUseItemObject")]
public class OnPlayerUseItemObject : ItemObject
{
    void Awake() 
    {
        base.Init(ItemType.OnPlayerUse);
    }
}
