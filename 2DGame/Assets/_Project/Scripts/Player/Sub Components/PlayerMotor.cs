using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Motor component of the player.
/// If the new input system is used this class should be re written and handed a reference to an input handler class.
/// </summary>
[Serializable]
public class PlayerMotor
{
    private Rigidbody2D _rb;
    private PlayerController _pc;

    [Tooltip("The movement speed of the player.")]
    [SerializeField] private float movementSpeed;
    
    [Tooltip("Allow for full player movement from an analogue stick, will need to separate inputs if use of this is desired later.")]
    [SerializeField] private bool useAnalogueMovement;
    
    //Dead zone still to be implemented, or possibly just relegated to Unity Input
    private float inputDeadzone = .1f;
    
    public void Initialize(PlayerController pc)
    {
        _pc = pc;
        _rb = _pc.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        _rb.velocity = GetMoveVector() * movementSpeed;
    }

    /// <summary>
    /// Calls appropriate method for input type selected by user.
    /// </summary>
    private Vector2 GetMoveVector()
    {
        if (useAnalogueMovement)
            return AnalogueMoveVector();
        else
            return RawMoveVector();
    }

    /// <summary>
    /// Get a normalized vector2 based on horizontal and vertical input.
    /// </summary>
    private Vector2 RawMoveVector()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    /// <summary>
    /// Get a normalized vector2 based on horizontal and vertical input.
    /// Takes into account a custom analogue dead zone value.
    /// </summary>
    private Vector2 AnalogueMoveVector()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Mathf.Abs(x) > inputDeadzone)
        {
            if (x > 0)
                x = 1;
            else
                x = -1;
        }
        
        if (Mathf.Abs(y) > inputDeadzone)
        {
            if (y > 0)
                y = 1;
            else
                y = -1;
        }
        return new Vector2(x, y);
    }
}
