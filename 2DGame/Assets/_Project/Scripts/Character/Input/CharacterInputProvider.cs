using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputProvider : MonoBehaviour
{
    private bool _attack;
    private Vector2 _movement;
    private Vector2 _hand;
    
    public bool Attack
    {
        get => _attack;
        set => _attack = value;
    }
    
    public Vector2 Movement
    {
        get => _movement;
        set => _movement = value;
    }

    public Vector2 Hand
    {
        get => _hand;
        set => _hand = value;
    }
}
