using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotData
{
    [SerializeField]    int amountOfSlots = 0;

    #region get set

    public int GetAmountOfSlots()
    {
        return this.amountOfSlots;
    }

    public void SetAmountOfSlots(int amountOfSlots)
    {
        this.amountOfSlots = amountOfSlots;
    }

    #endregion


}
