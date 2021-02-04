using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerentReference : MonoBehaviour
{
    [HideInInspector]   public GameObject perent;
    
    void Awake() 
    {
        perent = this.transform.parent.gameObject;    
    }
}
