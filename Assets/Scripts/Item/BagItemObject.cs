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

    public bool AddItem(ItemObject item)
    {
        innerItems.Add(item);
        return true;
    }

    public int GetSlotCount()
    {
        return bagSize.x * bagSize.y;
    }

    public bool IsFuLL()
    {
        return innerItems.Count == GetSlotCount();
    }

    public bool IsEmpty()
    {
        return innerItems.Count == 0;
    }

    #region get set

    public Vector2Int GetBagSize()
    {
        return bagSize;
    }

    public List<ItemObject> GetInnerItems()
    {
        return innerItems;
    }

    #endregion

    // void SaveInnerItem()
    // {
    //     string _innerItemsJson = JsonUtility.ToJson(innerItems);
    //     System.IO.File.WriteAllText(Application.persistentDataPath + "/innerItems.json", _innerItemsJson);
    // }
}
