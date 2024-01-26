using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    PlayerInputAction _playerInputActions;

    public event EventHandler OnMouseClick;

    private void Awake()
    {
        Instance = this;
        _playerInputActions = new PlayerInputAction();
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
        _playerInputActions.Player.MouseClick.performed += GetMouseClick;
    }

    private void GetMouseClick(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMouseClick?.Invoke(this, EventArgs.Empty);
    }
}
