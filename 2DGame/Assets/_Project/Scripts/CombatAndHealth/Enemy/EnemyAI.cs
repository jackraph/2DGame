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
    [SerializeField] public Vector2[] waypoints;
    private int currPointIndex = 0;
    
    //Enemy info.
    [Tooltip("The speed this enemy moves at.")]
    [SerializeField] private float speed;
    
    [Tooltip("The detection radius this enemy has in its patrol state. If a player enters this radius the enemy moves to attack state.")]
    [SerializeField] private float detectionRadius;

    //References to main class.
    private EnemyController _ec;
    private Rigidbody2D _rb;
    
    //Targetting
    private GameObject _playerObj;
    
    /// <summary>
    /// Serves the function of a constructor as we are unable to implement a real one since this class is serializable.
    /// </summary>
    public void Initialize(EnemyController ec)
    {
        _ec = ec;
        _rb = _ec.GetComponent<Rigidbody2D>();
        _playerObj = GameObject.FindGameObjectWithTag("Player");
    }
    
    /// <summary>
    /// Custom update function.
    /// Call in fixed update from main class.
    /// </summary>
    public void Update()
    {
        if (Vector2.Distance(_playerObj.transform.position, _rb.transform.position) < detectionRadius)
        {
            currentState = EnemyState.Attack;
        }
        else
        {
            currentState = EnemyState.Patrol;
        }
        
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
        if (currPointIndex < waypoints.Length)
        {
            //Get direction to next waypoint.
            Vector2 dir = waypoints[currPointIndex] - (Vector2) _rb.transform.position;
            dir = dir.normalized;
            //Move in that direction.
            _rb.velocity = dir * speed;

            if (Vector2.Distance(_rb.transform.position, waypoints[currPointIndex]) < 0.1f)
            {
                currPointIndex++;
            }
        }
        else
        {
            currPointIndex = 0;
        }

    }

    /// <summary>
    /// Attack state. Move towards player.
    /// </summary>
    private void Attack()
    {
        //Get direction to the player.
        Vector2 dir = _playerObj.transform.position - _rb.transform.position;
        dir = dir.normalized;
        //Move in that direction.
        _rb.velocity = dir * speed;
    }
}
