using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShoppingState : GameBaseState
{
    public override void OnStateEnter(GameManager gameManager)
    {
        gameManager.shopWindow.SetActive(true);
    }

    public override void StateUpdate(GameManager gameManager)
    {
    }

    public override void OnStateExit(GameManager gameManager)
    {
        gameManager.shopWindow.SetActive(false);
    }
}