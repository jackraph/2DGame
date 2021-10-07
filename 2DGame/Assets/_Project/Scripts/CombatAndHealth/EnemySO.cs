using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    [Tooltip("The name of this enemy. For example 'Wolf' or 'Spider'")]
    public string enemyName;
    
    [Tooltip("Brief description of the enemy. For example 'A mangy grey wolf.'")]
    public string description;
    
    [Tooltip("Attach the sprite associated with this enemy.'")]
    public Sprite sprite;

    [Tooltip("The base health value of this enemy. This value will be used by modifier system.")]
    public float baseHealth;

    [Tooltip("Details about ab attack type of this enemy.")]
    public AttackType[] attackTypes;
}

