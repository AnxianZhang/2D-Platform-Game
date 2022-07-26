using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttaque : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private uint damageDeal = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("bonjour");
        if (collision.CompareTag("Player"))
        {
            playerHealth.takeDamage(damageDeal);
        }
    }
}
