using System;
using System.Collections;
using System.Collections.Generic;
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
    
    [Serializable]
    public struct AttackType
    {
        [Tooltip("What is the name of the attack. For example 'Slash', 'Back-slash', 'Fireball'")]
        public string attackName;
    
        [Tooltip("Brief description of the attack. May be implemented into the game as a tooltip.")]
        public string attackDescription;
    
        [Tooltip("What is the range of this attack")]
        public float range;
        
        [Tooltip("How much base damage does this attack inflict? This value will be used by modifier system.")]
        public float baseDamage;
    }
}

