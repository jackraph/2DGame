using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made some slight changes to this script just so it's easier to implement an input class later.
//Didn't change any logic. -Jack
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField]
    private float movementSpeed = 10;
    
    [Tooltip("Allow for full player movement from an analogue stick, will need to separate inputs if use of this is desired later")]
    [SerializeField]
    private bool useAnalogueMovement = false;
    
    
    //Deadzone still to be implemented, or possibly just relegated to Unity Input
    private float inputDeadzone = .1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.velocity = GetMoveVector() * (Time.deltaTime * movementSpeed);
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
