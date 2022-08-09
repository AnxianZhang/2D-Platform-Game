using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    //private bool isTrigger = false;
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
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && this.isInRange)
        {
            //this.isTrigger = true;
            this.eC.isTrigger = true;
            this.pM.setIsClimbing(true);

//            print("oui");
        }
        //if (!this.isInRange)
        //    this.isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //position = collision.transform.position.y - ;
        if (collision.transform.CompareTag("Player"))
        {
            this.isInRange = true;
            //if (position.y < 0 && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            this.isInRange = false;
            this.pM.setIsClimbing(false);
            this.eC.isTrigger = false;
        }
    }
}
