using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffSet;

    private Vector3 posOffSet = new Vector3(2, 2, -10);
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 newCameraPos = new Vector3(this.player.transform.position.x, this.player.transform.position.y) + this.posOffSet;
        this.transform.position = Vector3.SmoothDamp(transform.position, newCameraPos, ref this.velocity, this.timeOffSet);
                                              //    actual pos        new pos   need to be here  the delay
    }
}
