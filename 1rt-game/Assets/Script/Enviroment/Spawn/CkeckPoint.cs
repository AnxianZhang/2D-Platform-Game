using UnityEngine;

public class CkeckPoint : MonoBehaviour
{
    private Animator animator;
    private Transform spwan;

    private void Start()
    {
        this.animator = transform.GetChild(0).GetComponent<Animator>();
        //this.animator = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<Animator>();
        this.spwan = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            if (this.animator.runtimeAnimatorController != null) 
            {
                this.animator.SetBool("IsTrigger", true);
                this.spwan.position = gameObject.transform.position;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
    }
}
