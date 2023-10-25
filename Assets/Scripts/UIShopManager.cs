using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIShopManager : MonoBehaviour
{
    #region Variables

    public static UIShopManager Instance;

    public int coinsQt;

    [SerializeField] private TMP_Text coinsQtText;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        coinsQt = 300;
    }

    private void Update()
    {
        coinsQtText.text = coinsQt.ToString();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Closes the shop by calling the ChangeGameState from GameManager.
    /// </summary>
    public void CloseShop()
    {
        GameManager.Instance.ChangeGameState(GameState.Playing);
    }

    #endregion
}