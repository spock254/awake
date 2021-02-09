using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemList<T> : IList<T>
{
    List<ItemObject> GetInnerItems();
    bool IsEmpty();
    bool IsFull();
}
