using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public bool isInRange;
    private PlayerMovement pM;

    private void Start()
    {
        this.pM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    //private void Update()
    //{
    //    if (this.isInRange && (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow)))
    //    {
    //        print("yes");
    //        this.pM.setIsClimbing(true);
    //    }

    //    else
    //    {
    //        print("no");
    //        this.pM.setIsClimbing(false);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            this.pM.setIsClimbing(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            this.pM.setIsClimbing(false);
    }
}
