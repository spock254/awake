using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
                        public int itemWeight;
    [SerializeField]    int slotID;



    #region get set

    public int GetSlotID()
    {
        return this.slotID;
    }

    public void SetSlotID(int slotID)
    {
        this.slotID = slotID;
    }

    #endregion

}
