using UnityEngine;

public class SnakeAttaque : MonoBehaviour
{
    private const int DAMAGEDEAL = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.takeDamage(DAMAGEDEAL);
        }
    }
}
