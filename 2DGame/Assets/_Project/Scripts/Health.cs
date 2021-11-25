using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthBar;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public float GetCurrHealth()
    {
        return currentHealth;
    }
}
