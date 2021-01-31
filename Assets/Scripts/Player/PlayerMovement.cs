using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;                               

    [HideInInspector]
    public Vector3 input = Vector3.zero;    
       
    Vector3 turn = Vector3.zero;  
    Vector3 movement = Vector3.zero;          
    bool isMoving = false;

    Vector2 diractionAccess = Vector2.zero;

    void Awake()
    { 
        
    }

    void Update()
    {
        input.x = GetAxisRawBasedOnAccess("Horizontal");
        input.y = GetAxisRawBasedOnAccess("Vertical");

        isMoving = (input != Vector3.zero);         

        if (isMoving == true)      
        {
            turn = input;
        }

        Vector3 direction = input.normalized;   
        movement = direction * speed;   
        transform.position += movement * Time.deltaTime;
                                                         
    }


    public void SetDiractionAccess(Vector2 newDirAccess)
    {
        
        diractionAccess = newDirAccess;
    }

    float GetAxisRawBasedOnAccess(string axisName)
    {
        float rawAxis = Input.GetAxisRaw(axisName);  
        
        if ((rawAxis > 0 && GetDirAccessValue(axisName) != 1) 
        || (rawAxis < 0 && GetDirAccessValue(axisName) != -1))
        {
            return rawAxis;
        }

        return 0;
    }

    float GetDirAccessValue(string axisName)
    {
        if (axisName == "Horizontal")
        {
            return diractionAccess.x;
        }

        return diractionAccess.y;
    }

    public Vector2 GetDiractionAccess()
    {
        return diractionAccess;
    }

    public Vector3 GetTurnSide() 
    {
        return turn;
    }

    public bool IsPlayerMoving() 
    {
        return isMoving;
    }
}
