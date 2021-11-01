using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple class for handling the AI of an enemy.
/// Not a mono behaviour so the custom update method will have to be called by the main class.
/// Serializable for easier designing in the editor.
/// Not gonna bother with a proper state machine just gonna use if checks + enum for this project.
/// </summary>
[Serializable]
public class EnemyAI
{
    //States.
    private enum EnemyState { Patrol, Attack }
    [SerializeField] private EnemyState currentState = EnemyState.Patrol;
    
    //Waypoints.
    [Tooltip("Each waypoint is connected to the previous and the next waypoint in the list. Starting position is not stored as a waypoint.")]
    [SerializeField] private Vector2[] waypoints;


    //References to main class.
    private EnemyController _ec;
    private Rigidbody2D _rb;
    
    /// <summary>
    /// Serves the function of a constructor as we are unable to implement a real one since this class is serializable.
    /// </summary>
    public void Initialize(EnemyController ec)
    {
        _ec = ec;
        _rb = _ec.GetComponent<Rigidbody2D>();
    }
    
    /// <summary>
    /// Custom update function.
    /// Call in fixed update from main class.
    /// </summary>
    public void Update()
    {
        if (currentState == EnemyState.Patrol)
        {
            Patrol();
        }
        else
        {
            Attack();
        }
    }
    
    /// <summary>
    /// Patrol state. Move to next waypoint.
    /// </summary>
    private void Patrol()
    {
        
    }

    /// <summary>
    /// Attack state. Move towards player.
    /// </summary>
    private void Attack()
    {
        
    }
}
