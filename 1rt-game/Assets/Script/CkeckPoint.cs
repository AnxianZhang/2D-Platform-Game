using UnityEngine;

public class CkeckPoint : MonoBehaviour
{
    private Animator animator;
    private Transform spwan;

    private void Start()
    {
        this.animator = gameObject.GetComponentInChildren<Animator>();
        this.spwan = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && this.animator.GetBool("IsTrigger") == false)
        {
            this.animator.SetBool("IsTrigger", true);
            this.spwan.position = gameObject.transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
