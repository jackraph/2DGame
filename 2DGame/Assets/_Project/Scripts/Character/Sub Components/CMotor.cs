using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the character based on movement input.
/// </summary>
[Serializable]
public class CMotor
{
    private CController _cc;
    private Rigidbody2D _rb;
    private CharacterInputHandler _input;
    
    [SerializeField] private float moveSpeed;
    
    /// <summary>
    /// This coefficient is accessed by the mandatory IModifiable methods in the controller class.
    /// </summary>
    public float MoveSpeedCoEfficient { get; set; }

    /// <summary>
    /// Serves the role of a constructor as this class is serializable in the editor.
    /// </summary>
    public void Initialize(CController cc, CharacterInputHandler input)
    {
        _cc = cc;
        _rb = _cc.GetComponent<Rigidbody2D>();
        _input = input;
        MoveSpeedCoEfficient = 1;
    }

    /// <summary>
    /// Update method for this class. Called by the controller where appropriate.
    /// </summary>
    public void Update()
    {
        _rb.velocity = _input.Movement * (moveSpeed * MoveSpeedCoEfficient) ;
    }
}
