using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private uint maxHealth = 100;
    public uint currentHealth;

    public HealthBar healtBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healtBar.initHealth(currentHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            print("soir");
            takeDamage(5);
        }
    }

    void takeDamage(uint amount)
    {
        //if (currentHealth - amount > 0)
        //{
            currentHealth -= amount;
            healtBar.setHealth(currentHealth);
        //}
    }
}
