using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayerSorter : MonoBehaviour
{
    #region Variables

    private Transform _playerTransform;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private int orderInLayerBehind, orderInLayerFront;
    [SerializeField] private float yOffset;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerTransform = PlayerController.Instance.transform;
    }

    private void Update()
    {
        // Updating the spriteRenderer sortingOder using the player's [y] position as reference.
        _spriteRenderer.sortingOrder = _playerTransform.position.y < transform.position.y - yOffset ? orderInLayerFront : orderInLayerBehind;
    }

    #endregion
}