﻿using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerInput
{
    private const float DefaultSensitivity = 0.25f;

    #region Serialized Fields

    [Header("Camera")]
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private Transform cameraTarget;

    [SerializeField]
    private Vector2 minMaxCameraPitch = new(-40f, 85f);

    [SerializeField]
    private Vector2 minMaxCameraZoom = new(2f, 5f);

    [SerializeField]
    private float cameraZoomStep = 0.2f;

    [SerializeField]
    private LayerMask cameraCollisionMask;

    [SerializeField]
    private float cameraCollisionRadius = 0.4f;

    [SerializeField]
    private float cameraMinObstacleDistance = 0.1f;

    #endregion

    private float cameraCurrentZoom;
    private Vector3 cameraOrbit;
    private float cameraSensitivity;
    private float currentCameraDistance;

    private void StartCamera()
    {
        cameraCurrentZoom = (minMaxCameraZoom.x + minMaxCameraZoom.y) / 2f;

        cameraOrbit.x = (minMaxCameraPitch.x + minMaxCameraPitch.y) / 2f;
        cameraOrbit.y = transform.rotation.eulerAngles.y;
    }

    private void OnEnableCamera()
    {
        Settings.SettingChanged += OnMouseSensitivityChange;

        cameraSensitivity = Settings.MouseSensitivity * DefaultSensitivity;
    }

    private void OnDisableCamera()
    {
        Settings.SettingChanged -= OnMouseSensitivityChange;
    }

    private void OnMouseSensitivityChange(string settingKey)
    {
        if (settingKey != Settings.MouseSensitivityKey)
        {
            return;
        }

        cameraSensitivity = Settings.MouseSensitivity * DefaultSensitivity;
    }

    // Retrieve camera input
    private void MoveCamera()
    {
        var moveOffset = actions.CameraMove.ReadValue<Vector2>() * cameraSensitivity;

        cameraOrbit.x = Mathf.Clamp(cameraOrbit.x - moveOffset.y, minMaxCameraPitch.x, minMaxCameraPitch.y);
        cameraOrbit.y += moveOffset.x;
    }

    // Update camera rotation and position
    private void UpdateCamera()
    {
        const float raycastSphereRadius = 0.5f;

        var target = cameraTarget.position;
        var lookRotation = Quaternion.Euler(cameraOrbit);
        var lookDirection = lookRotation * Vector3.forward;

        // Set camera distance to the selected zoom by default
        var cameraDistance = cameraCurrentZoom;

        // Raycast to check if the camera has obstacles
        var cast = Physics.SphereCast(target, raycastSphereRadius, -lookDirection, out var hit,
            cameraDistance + cameraMinObstacleDistance, cameraCollisionMask, QueryTriggerInteraction.Ignore);

        if (cast)
        {
            cameraDistance = Mathf.Max(0f, hit.distance - cameraMinObstacleDistance);
        }

        // Set camera position to the circle orbit around the player head if the obstacle is too close
        if (cameraDistance < cameraCollisionRadius)
        {
            cameraDistance = 0f;

            target = new Vector3(
                target.x - cameraCollisionRadius * Mathf.Sin(cameraOrbit.y * Mathf.Deg2Rad),
                target.y,
                target.z - cameraCollisionRadius * Mathf.Cos(cameraOrbit.y * Mathf.Deg2Rad));
        }

        // Smoothly change distance between the camera and the target
        currentCameraDistance = Mathf.MoveTowards(currentCameraDistance, cameraDistance, Time.deltaTime * 10f);

        playerCamera.transform.SetPositionAndRotation(target - lookDirection * currentCameraDistance, lookRotation);
    }

    private void OnCameraZoomChange(InputAction.CallbackContext obj)
    {
        var value = actions.CameraZoom.ReadValue<Vector2>();
        var change = value.y < 0 ? cameraZoomStep : -cameraZoomStep;

        cameraCurrentZoom = Mathf.Clamp(cameraCurrentZoom + change, minMaxCameraZoom.x, minMaxCameraZoom.y);
    }
}
