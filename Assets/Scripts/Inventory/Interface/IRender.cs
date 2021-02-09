using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRender
{
    void Add(ItemObject item);

    int GetFreeSlotID(ItemObject container);
}
