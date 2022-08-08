using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement pM;
    private EdgeCollider2D eC;

    private Vector2 position;

    private void Start()
    {
        this.pM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        this.eC = GameObject.FindGameObjectWithTag("LadderPlat").GetComponent<EdgeCollider2D>();
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

    private void Update()
    {
        //if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && this.isInRange)
        //{
        //    this.eC.isTrigger = true; 
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //position = collision.transform.position.y - ;
        if (collision.transform.CompareTag("Player"))
        {
            //this.isInRange = true;
            //if (position.y < 0 && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            this.eC.isTrigger = true;
            this.pM.setIsClimbing(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //this.isInRange = false;
            this.pM.setIsClimbing(false);
            this.eC.isTrigger = false;
        }
    }
}
