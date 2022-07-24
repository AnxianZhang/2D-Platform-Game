using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rB;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Animator animator;

    public SpriteRenderer sR; // player visual

    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    private bool isOnGroud;

    private Vector3 velocity = Vector3.zero; // initialize to (0, 0, 0) 

    private void Update()
    {
        isOnGroud = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position); // Checks if a Collider falls within a rectangular area
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGroud)
            rB.AddForce(new Vector2(0f, jumpForce));
    }
    void FixedUpdate()
    {
        float HMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        movePlayer(HMovement);

        flip();
        float playerVelocity = Mathf.Abs(rB.velocity.x); // absolut value
        animator.SetFloat("Speed", playerVelocity);
    }

    void movePlayer(float _HMovement)
    {
        Vector3 targetVelocity = new Vector2(_HMovement, rB.velocity.y);
        rB.velocity = Vector3.SmoothDamp(rB.velocity, targetVelocity, ref velocity, 0.05f);
    }

    void flip()
    {
        if (rB.velocity.x > 0.1)
            sR.flipX = false;
        else if (rB.velocity.x < -0.1)
            sR.flipX = true;
    }
}
