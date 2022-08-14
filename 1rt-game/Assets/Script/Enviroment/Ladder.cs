using System.Collections;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    //private bool isTrigger = false;
    private PlayerMovement pM;
    private EdgeCollider2D[] eC ;
    private Animator animator;
    private BoxCollider2D bC;

    private Vector2 position;

    private void Start()
    {
        this.pM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        this.eC = GameObject.FindGameObjectWithTag("LadderPlat").GetComponents<EdgeCollider2D>();
        this.animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
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

    private void setTrigger(bool state)
    {
        foreach (EdgeCollider2D eC in this.eC)
            eC.isTrigger = state;
    }

    private void Update()
    {
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && this.isInRange)
        {
            //this.isTrigger = true;
            setTrigger(true);
            this.pM.setIsClimbing(true);
            this.animator.SetBool("isClimbing", true);
            //print("oui");
        }//else
        //    this.animator.SetBool("isClimbing", false);
        ////if (!this.isInRange)
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
            //this.eC.isTrigger = false;
            this.animator.SetBool("isClimbing", false);
            StartCoroutine(showCollider());
        }
    }
    private IEnumerator showCollider()
    {
        yield return new WaitForSeconds(.3f);
        setTrigger(false);
    }
}
