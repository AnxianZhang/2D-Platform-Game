using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePatrol : MonoBehaviour
{
    public float Speed;
    public Transform[] wayPoints;
    public SpriteRenderer sR;

    private Transform target;
    private int idxNextWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        this.target = this.wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 distance = this.target.position - this.transform.position;
        this.transform.Translate(distance.normalized * this.Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(this.target.position, this.transform.position) < 0.3f)
        {
            this.idxNextWayPoint = Random.Range(0, this.wayPoints.Length);
            this.target = wayPoints[this.idxNextWayPoint];
            flip();
        }
    }

    void flip()
    {
        float speed = (this.target.position.x - this.transform.position.x) / Time.deltaTime;
        if (speed < 0.1)
            this.sR.flipX = true;
        else if (speed > -0.1)
            this.sR.flipX = false;
    }
}
