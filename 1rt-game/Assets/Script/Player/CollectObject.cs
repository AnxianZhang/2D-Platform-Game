using UnityEngine;

public class CollectObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Inventory.getInventory().addCoins(1);
            Destroy(gameObject);
        }
    }
}
