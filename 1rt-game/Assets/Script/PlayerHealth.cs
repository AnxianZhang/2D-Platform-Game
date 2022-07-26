using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private uint maxHealth = 100;
    public uint currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.initHealth(currentHealth);
        //currentHealth -= 80;
        //healthBar.setHealth(currentHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) //test
            takeDamage(20);
    }

    public void takeDamage(uint amount)
    {
        if (currentHealth - amount > 0)
        {
            currentHealth -= amount;
            healthBar.setHealth(currentHealth);
        }
    }
}
