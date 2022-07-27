using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rB;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask ignoreLayer;

    public Animator animator;

    public SpriteRenderer sR; // player visual

    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    private bool isOnGroud;

    private float HMovement;

    private Vector3 velocity = Vector3.zero; // initialize to (0, 0, 0) 

    private void Update() // input is always here
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && this.isOnGroud)
            this.isJumping = true;
        
        flip();
        float playerVelocity = Mathf.Abs(this.rB.velocity.x); // absolut value
        this.animator.SetFloat("Speed", playerVelocity);
    }
    void FixedUpdate() // in relation with physics ex: all madifiction with rigidbody (e.g velocity)
    {
        this.HMovement = Input.GetAxis("Horizontal") * this.moveSpeed * Time.deltaTime;

        //this.isOnGroud = Physics2D.OverlapArea(this.groundCheckLeft.position, this.groundCheckRight.position); // Checks if a Collider falls within a rectangular area
        this.isOnGroud = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ignoreLayer); // Checks if a Collider falls within a circle area

        movePlayer();
    }

    void movePlayer()
    {
        
        if (this.isJumping && this.isOnGroud)
        {
            this.rB.AddForce(new Vector2(0f, this.jumpForce));
            this.isJumping = false;
        }

        Vector3 targetVelocity = new Vector2(this.HMovement, this.rB.velocity.y);
        this.rB.velocity = Vector3.SmoothDamp(this.rB.velocity, targetVelocity, ref this.velocity, 0.05f);
    }

    void flip()
    {
        if (this.rB.velocity.x > 0.1)
            this.sR.flipX = false;
        else if (this.rB.velocity.x < -0.1)
            this.sR.flipX = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
