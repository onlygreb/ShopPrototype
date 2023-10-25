using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameBaseState
{
    public abstract void OnStateEnter(GameManager gameManager);
    public abstract void StateUpdate(GameManager gameManager);
    public abstract void OnStateExit(GameManager gameManager);
}
