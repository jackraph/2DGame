using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reads input from unities new input system.
public class PlayerCharacterInputProvider : CharacterInputProvider
{
    private PlayerActions _inputActions;

    private void Awake()
    {
        _inputActions = new PlayerActions();
        _inputActions.Enable();
    }

    private void Update()
    {
        base.Attack = _inputActions.PlayerControls.Attack.ReadValue<float>();
        base.Movement = _inputActions.PlayerControls.Movement.ReadValue<Vector2>();
    }
}
