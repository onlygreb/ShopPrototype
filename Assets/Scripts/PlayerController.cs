using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    
    public static PlayerController Instance;

    private Rigidbody2D _rb;
    private GameManager _gameManager;
    private PlayerAnimationController _pAC;

    [SerializeField] private float playerSpeed;
    private bool _canWalk;

    private int _lastLookingDir;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //Initializing components.
        _rb = GetComponent<Rigidbody2D>();
        _gameManager = GameManager.Instance;
        _pAC = GetComponent<PlayerAnimationController>();

        GameManager.OnGameStateChanged += UpdateCanWalk;
        _lastLookingDir = 0;
    }

    private void FixedUpdate()
    {
        if (_canWalk)
            Move();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Player movement using RigidBody, also calls UpdateAnimators function.
    /// </summary>
    private void Move()
    {
        Vector2 playerDir = _gameManager.pInputActions.InGame.Movement.ReadValue<Vector2>();

        _rb.velocity = playerDir * playerSpeed;

        if (playerDir.x != 0 || playerDir.y != 0)
        {
            if (playerDir.y > 0) _lastLookingDir = 1;
            else if (playerDir.y < 0) _lastLookingDir = 0;
            else if (playerDir.x > 0) _lastLookingDir = 2;
            else if (playerDir.x < 0) _lastLookingDir = 3;

            _pAC.UpdateAnimators(_lastLookingDir, true);
        }
        else
        {
            _pAC.UpdateAnimators(_lastLookingDir, false);
        }
    }

    /// <summary>
    /// Updates the _canWalk boolean.
    /// </summary>
    /// <param name="state"></param>
    private void UpdateCanWalk(GameState state)
    {
        switch (state)
        {
            case GameState.Playing:
                _canWalk = true;
                break;
            case GameState.Shopping:
                _canWalk = false;
                break;
            default:
                _canWalk = false;
                break;
        }
    }

    #endregion
}