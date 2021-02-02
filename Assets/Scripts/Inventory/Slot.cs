using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Slot : MonoBehaviour
{
                        int slotID;
    [SerializeField]    ItemObject item = null;
                        bool isOccupied = false;
                        Image slotImg = null;

    void Awake() 
    {
        slotImg = GetComponent<Image>();    
    }

    #region get set
    
    public void SetSlotID(int id)
    {
        this.slotID = id;
    }

    public int GetSlotID()
    {
        return slotID;
    }

    public void SetIsOccupied(bool isOccupied)
    {
        this.isOccupied = isOccupied;
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetItem(ItemObject item)
    {
        this.item = item;
    }

    public ItemObject GetItem()
    {
        return item;
    }

    #endregion



}
