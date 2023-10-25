using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : GameBaseState
{
    public override void OnStateEnter(GameManager gameManager)
    {
        gameManager.pInputActions.InGame.Enable();
    }

    public override void StateUpdate(GameManager gameManager)
    {
    }

    public override void OnStateExit(GameManager gameManager)
    {
        gameManager.pInputActions.InGame.Disable();
    }
}