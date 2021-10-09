using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Tooltip("Attach the attack animation clip for this particular attack.")]
    public AnimationClip attackAnimation;
}
