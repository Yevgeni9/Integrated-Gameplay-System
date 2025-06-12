using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private int maxHealth;
    private int currentHealth;
    private HealthBar healthBar;

    public HealthSystem(int maxHealth, HealthBar healthbar)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth; // Sets maxHealth
        this.healthBar = healthbar;

        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }
}
