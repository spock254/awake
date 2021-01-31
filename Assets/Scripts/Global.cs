using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    
    public static class Component
    {
        public static CollisionCounter GetCollisionCounter()
        {
            return GameObject.FindGameObjectWithTag("CollisionCounter").GetComponent<CollisionCounter>();
        }

        public static PlayerMovement GetPlayerMovment()
        {
            return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }
    }
}
