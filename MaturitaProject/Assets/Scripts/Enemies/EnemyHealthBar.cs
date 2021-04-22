using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public HealthBar healthBar;

    public Enemy enemy;

    private int currentHealth;
    private int maxHealth;

    void Start()
    {
        maxHealth = enemy.GetMaxHealth();
        currentHealth = enemy.GetCurrentHealth();
        healthBar.setMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    void Update()
    {
        currentHealth = enemy.GetCurrentHealth();

        healthBar.SetHealth(currentHealth);
    }
}
