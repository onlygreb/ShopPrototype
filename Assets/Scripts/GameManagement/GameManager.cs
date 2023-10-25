using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public static GameManager Instance;
    private GameBaseState _currentState;

    [HideInInspector] public GamePlayingState gamePlayingState = new GamePlayingState();
    [HideInInspector] public GameShoppingState gameShoppingState = new GameShoppingState();

    public static Action<GameState> OnGameStateChanged;

    public PlayerInputActions pInputActions;

    public GameObject shopWindow;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        Instance = this;
        pInputActions = new PlayerInputActions();
    }

    private void Start()
    {
        ChangeGameState(GameState.Playing);
    }

    private void Update()
    {
        _currentState.StateUpdate(this);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Change the game state providing the new State
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeGameState(GameState newState)
    {
        GameBaseState newGameState;
        if (newState == GameState.Playing) newGameState = gamePlayingState;
        else newGameState = gameShoppingState;

        _currentState?.OnStateExit(this);
        _currentState = newGameState;
        _currentState?.OnStateEnter(this);

        OnGameStateChanged?.Invoke(newState);
    }

    #endregion
}

public enum GameState
{
    Playing,
    Shopping
}