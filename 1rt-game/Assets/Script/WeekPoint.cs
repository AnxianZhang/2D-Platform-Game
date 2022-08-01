using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeekPoint : MonoBehaviour
{
    private GameObject objectToDestroy;

    private void Start()
    {
        this.objectToDestroy = transform.parent.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            Destroy(objectToDestroy);
    }
}
