using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRender
{
    void Add(ItemObject item);
    void Remove(ItemObject item);
    
    int GetFreeSlotID(ItemObject container);
}
