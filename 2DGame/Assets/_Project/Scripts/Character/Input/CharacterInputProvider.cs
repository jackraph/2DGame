using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputProvider : MonoBehaviour
{
    private float _attack;
    private Vector2 _movement;
    
    public float Attack
    {
        get { return _attack;}
        set { _attack = value; }
    }

    public Vector2 Movement
    {
        get { return _movement;}
        set { _movement = value; }
    }
}
