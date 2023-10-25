using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopInteractablePerProximity : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject InteractableText;

    private bool _canOpenShop;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        GameManager.Instance.pInputActions.InGame.Interact.performed += OpenShop;
        _canOpenShop = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canOpenShop = true;
            InteractableText.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canOpenShop = false;
            InteractableText.SetActive(false);
        }
    }

    #endregion

    #region Methods

    private void OpenShop(InputAction.CallbackContext context)
    {
        if (!_canOpenShop) return;
        
        GameManager.Instance.ChangeGameState(GameState.Shopping);
    }

    #endregion
}
