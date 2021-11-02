using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HealthSystem
{
    [Tooltip("The maximum and default health of this object.")]
    [SerializeField] private float maxHealth;
    private float _currHealth;

    [Tooltip("The UI canvas is attached here.")]
    [SerializeField] private Canvas canvas;
    
    

    public void Initialize()
    {
        _currHealth = maxHealth;
        
        //Generate healthbar UI element here.
    }

}
