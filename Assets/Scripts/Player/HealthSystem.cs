using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public HealthSystem(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void TakeDamage (int amount)
    {
        CurrentHealth -= amount;
    }
}
