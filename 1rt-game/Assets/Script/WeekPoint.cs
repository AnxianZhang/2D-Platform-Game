using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeekPoint : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            Destroy(objectToDestroy);
    }
}
