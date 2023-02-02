using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Input Receiver")]
public class InputReceiver : ScriptableObject
{
    [SerializeField] EventManager _eventManager;

    PlayerInputActions _inputActions;

    public Vector2 DirectionInput { get; private set; }

    public void Init()
    {
        _inputActions = new PlayerInputActions();

        _inputActions.Gameplay.Movement.performed += ctx => DirectionInput = ctx.ReadValue<Vector2>();
        _inputActions.Gameplay.Movement.canceled += _ => DirectionInput = Vector2.zero;

        _inputActions.Enable();
    }
}
