using UnityEngine;

public class SnakePatrol : MonoBehaviour
{
    public Transform[] wayPoints;
    
    private SpriteRenderer sR;
    private const float SPEED = 1.3f;

    private Transform target;
    private int idxNextWayPoint;

    // Start is called before the first frame update
    void Start()
    {

        this.sR = gameObject.GetComponent<SpriteRenderer>();
        this.target = this.wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 distance = this.target.position - this.transform.position;
        this.transform.Translate(distance.normalized * SPEED * Time.deltaTime, Space.World);

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
