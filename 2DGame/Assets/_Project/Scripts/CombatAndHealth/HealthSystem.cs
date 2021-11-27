using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private Image HealthBar;
    [Tooltip("The maximum and default health of this object.")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float _currHealth;
    
    public void Awake()
    {
        _currHealth = maxHealth;
    }

    public void Update()
    {
        HealthBar.fillAmount = _currHealth / maxHealth;
    }

    /// <summary>
    /// Called to change the current health of this system. Can be a negative or positive amount.
    /// </summary>
    public void HealthChange(float amount)
    {
        _currHealth += amount;
        if (_currHealth > maxHealth)
        {
            _currHealth = maxHealth;
        }

        if (_currHealth < 0)
        {
            _currHealth = 0;
        }
    }

}
