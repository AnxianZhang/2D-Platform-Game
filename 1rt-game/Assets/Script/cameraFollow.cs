using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private GameObject player;
    private const float TIME_OFFSET = 0.2f;

    private Vector3 posOffSet;
    private Vector3 velocity;

    private void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.posOffSet = new Vector3(2, 2, -10);
        this.velocity = Vector3.zero;
    }

    void Update()
    {
        Vector3 newCameraPos = new Vector3(this.player.transform.position.x, this.player.transform.position.y) + this.posOffSet;
        this.transform.position = Vector3.SmoothDamp(transform.position, newCameraPos, ref this.velocity, TIME_OFFSET);
                                              //    actual pos        new pos   need to be here  the delay
    }
}
