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

    public bool TryAddItem(ItemObject item)
    {
        // TODO
        innerItems.Add(item);

        return true;
    }

    #region get set

    public Vector2Int GetBagSize()
    {
        return bagSize;
    }

    #endregion

    public int GetSlotCount()
    {
        return bagSize.x * bagSize.y;
    }
}
