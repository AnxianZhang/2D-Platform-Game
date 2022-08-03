using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float GROUD_CHECK_RADIUS = .36f;
    private const float MOVE_SPEED = 250;
    private const float JUMP_FORCE = 250;

    public LayerMask ignoreLayer;
    public Transform groundCheck; // this attribut in public is necessary, otherwise OnDrawGizmos will be unuseble

    private Rigidbody2D rB;
    private Animator animator;
    private SpriteRenderer sR; // player visual

    private bool isJumping;
    private bool isOnGroud;

    private Vector3 velocity;

    private void Start()
    {
        this.rB = gameObject.GetComponent<Rigidbody2D>();
        this.groundCheck = transform.GetChild(0).GetComponent<Transform>();
        this.animator = gameObject.GetComponent<Animator>();
        this.sR = gameObject.GetComponent<SpriteRenderer>();
        this.velocity = Vector3.zero;// initialize to (0, 0, 0) 
    }

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
        float hMovement = Input.GetAxis("Horizontal") * MOVE_SPEED * Time.deltaTime;

        //this.isOnGroud = Physics2D.OverlapArea(this.groundCheckLeft.position, this.groundCheckRight.position); // Checks if a Collider falls within a rectangular area
        this.isOnGroud = Physics2D.OverlapCircle(groundCheck.position, GROUD_CHECK_RADIUS, ignoreLayer); // Checks if a Collider falls within a circle area

        movePlayer(hMovement);
    }

    void movePlayer(float _hMovement)
    {
        
        if (this.isJumping && this.isOnGroud)
        {
            this.rB.AddForce(new Vector2(0f, JUMP_FORCE));
            this.isJumping = false;
        }

        Vector3 targetVelocity = new Vector2(_hMovement, this.rB.velocity.y);
        this.rB.velocity = Vector3.SmoothDamp(this.rB.velocity, targetVelocity, ref this.velocity, 0.05f);
    }

    void flip()
    {
        if (this.rB.velocity.x > .25f)
            this.sR.flipX = false;
        else if (this.rB.velocity.x < -.25f)
            this.sR.flipX = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, GROUD_CHECK_RADIUS);
    }
}
