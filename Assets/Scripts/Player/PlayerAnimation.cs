using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerMovement playerMovement;

    Dictionary<Vector2, string> playerMoveAnims = new Dictionary<Vector2, string>();
    Dictionary<Vector2, string> playerIdleAnims = new Dictionary<Vector2, string>();

    private void Awake() 
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();  

        playerMoveAnims.Add(new Vector2(-1, 0), "walk L");
        playerMoveAnims.Add(new Vector2(1, 0), "walk R");
        playerMoveAnims.Add(new Vector2(0, 1), "walk U");
        playerMoveAnims.Add(new Vector2(0, -1), "walk D");

        playerMoveAnims.Add(new Vector2(-1, -1), "walk DL");
        playerMoveAnims.Add(new Vector2(1, -1), "walk DR");
        playerMoveAnims.Add(new Vector2(1, 1), "walk UR");
        playerMoveAnims.Add(new Vector2(-1, 1), "walk UL");

        playerIdleAnims.Add(new Vector2(-1, 0), "idle L");
        playerIdleAnims.Add(new Vector2(1, 0), "idle R");
        playerIdleAnims.Add(new Vector2(0, 1), "idle U");
        playerIdleAnims.Add(new Vector2(0, -1), "idle D");

        playerIdleAnims.Add(new Vector2(0, 0), "idle D");

        playerIdleAnims.Add(new Vector2(-1, -1), "idle DL");
        playerIdleAnims.Add(new Vector2(1, -1), "idle DR");
        playerIdleAnims.Add(new Vector2(1, 1), "idle UR");
        playerIdleAnims.Add(new Vector2(-1, 1), "idle UL");  
    }

    void Update() 
    {
        if (playerMovement.IsPlayerMoving() == true)
        {
            anim.Play(playerMoveAnims[playerMovement.input]);
        }
        else 
        {
            anim.Play(playerIdleAnims[playerMovement.GetTurnSide()]);
        }
    }
}
