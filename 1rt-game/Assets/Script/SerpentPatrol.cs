using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpentPatrol : MonoBehaviour
{
    public float Speed;
    public Transform[] wayPoints;

    private Transform target;
    private int idxNextWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        target = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 distance = target.position - transform.position;
        transform.Translate(distance.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) < 0.3f)
        {
            idxNextWayPoint = Random.Range(0, wayPoints.Length);
            target = wayPoints[idxNextWayPoint];
        }
    }
}
