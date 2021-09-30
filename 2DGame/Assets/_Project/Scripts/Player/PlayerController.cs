using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 10;
    [Tooltip("Allow for full player movement from an analogue stick, currently smooths WASD too, will need to separate inputs if use of this is desired later")]
    public bool useAnalogueMovement = false;
    //Deadzone still to be implemented, or possibly just relegated to Unity Input
    float inputDeadzone = .1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.velocity = (GetMoveVector() * movementSpeed);
    }

    Vector2 GetMoveVector()
    {
        if(useAnalogueMovement)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            Vector2 moveVector = new Vector2(horizontalMovement, verticalMovement);
            return moveVector;
        }

        else
        {
            float horizontalMovement = 0, verticalMovement = 0;

            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > inputDeadzone)
            {
                if(Input.GetAxisRaw("Horizontal") > 0)
                {
                    horizontalMovement = 1;
                }
                else
                {
                    horizontalMovement = -1;
                }
                
            }
            if(Mathf.Abs(Input.GetAxisRaw("Vertical")) > inputDeadzone)
            {
                if(Input.GetAxisRaw("Vertical") > 0)
                {
                    verticalMovement = 1;
                }
                else
                {
                    verticalMovement = -1;
                }
            }

            Vector2 moveVector = new Vector2(horizontalMovement, verticalMovement).normalized;
            return moveVector;
        }
    }
}
