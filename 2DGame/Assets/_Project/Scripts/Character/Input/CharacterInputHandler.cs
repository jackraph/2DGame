using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles character input read from a provider.
//The provider could either be an AI or player input, this allows for same controller to be used by both AI and the player.

[Serializable]
public class CharacterInputHandler
{
    //We use poly morphism here to allow for an AI to provide its own input.
    [SerializeField] private CharacterInputProvider _provider;

    private InputStates _states;
    
    public bool Attack
    {
        get { return _states.Attack;}
        set { _states.Attack = value; }
    }
    
    
    public Vector2 Movement
    {
        get { return _states.Movement; }
        set { _states.Movement = value; }
    }

    public Vector2 Hand
    {
        get => _states.Hand;
        set => _states.Hand = value;
    }

    //Must be called by whatever controller is using this input handler.
    public void Update()
    {
        Attack = _provider.Attack;
        Movement = _provider.Movement;
        Hand = _provider.Hand;

    }
}

//Simple struct to store our input we have gotten from the provider.
public struct InputStates
{
    public bool Attack;

    public Vector2 Movement;

    public Vector2 Hand;
}
