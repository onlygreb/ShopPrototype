using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables

    private PlayerController _pController;

    [SerializeField] private float cameraSpeed;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _pController = PlayerController.Instance;
    }

    private void FixedUpdate()
    {
        // Get Player's Position
        Vector3 playerReferencePosition =
            new Vector3(_pController.transform.position.x, _pController.transform.position.y, -10);
        
        // Camera movement using Lerp to give a smooth aspect
        Vector3 lerpPosition = Vector3.Lerp(transform.position, playerReferencePosition, cameraSpeed);
        transform.position = lerpPosition;
    }

    #endregion
}