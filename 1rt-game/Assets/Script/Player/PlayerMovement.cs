using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float GROUD_CHECK_RADIUS = .36f;
    private const float JUMP_FORCE = 250;

    private float MOVE_SPEED = 5;

    public LayerMask ignoreLayer;
    public Transform groundCheck; // this attribut in public is necessary, otherwise OnDrawGizmos will be unuseble

    private Rigidbody2D rB;
    private Animator animator;
    private SpriteRenderer sR; // player visual

    public bool isJumping;
    public bool isOnGroud;
    public bool isClimbing;
    public bool isDied;
    private float hMovement;
    private float vMovement;

   // private Vector3 velocity;

    private void Start()
    {
        this.rB = gameObject.GetComponent<Rigidbody2D>();
        this.groundCheck = transform.GetChild(0).GetComponent<Transform>();
        this.animator = gameObject.GetComponent<Animator>();
        this.sR = gameObject.GetComponent<SpriteRenderer>();
        //this.velocity = Vector3.zero;// initialize to (0, 0, 0) 
    }

    private void Update() // input is always here
    {
        // if(this.isClimbing)

        if (!this.isDied)
        {
            this.hMovement = Input.GetAxis("Horizontal") * MOVE_SPEED;
            this.vMovement = 0f;
            if (this.isClimbing)
                this.vMovement = Input.GetAxis("Vertical") * MOVE_SPEED;

            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && this.isOnGroud && !this.isClimbing)
                this.isJumping = true;

            flip();
            float playerVelocity = Mathf.Abs(this.rB.velocity.x); // absolut value
            this.animator.SetFloat("Speed", playerVelocity);
        }
    }
    void FixedUpdate() // in relation with physics ex: all madifiction with rigidbody (e.g velocity)
    {
        if (!this.isDied)
        {
            //this.isOnGroud = Physics2D.OverlapArea(this.groundCheckLeft.position, this.groundCheckRight.position); // Checks if a Collider falls within a rectangular area
            this.isOnGroud = Physics2D.OverlapCircle(groundCheck.position, GROUD_CHECK_RADIUS, ignoreLayer); // Checks if a Collider falls within a circle area
                                                                                                             //this.isOnGroud = Physics2D.OverlapCircle(groundCheck.position, GROUD_CHECK_RADIUS, 64 + 128); // Checks if a Collider falls within a circle area

            movePlayer();
        }
    }

    void movePlayer()
    {
        //Vector3 targetVelocity;
        if (!this.isClimbing)
        {
            //print("no");
            if (this.isJumping && this.isOnGroud)
            {
                this.rB.AddForce(new Vector2(0f, JUMP_FORCE));
                this.isJumping = false;
            }

            //targetVelocity = new Vector2(this.hMovement, this.rB.velocity.y);
            //this.rB.velocity = Vector3.SmoothDamp(this.rB.velocity, targetVelocity, ref this.velocity, 0.05f);
            this.rB.velocity = new Vector2(this.hMovement, this.rB.velocity.y);
        }
        else
        {
            this.isJumping = false;
            this.rB.velocity = new Vector2(this.hMovement, this.vMovement);
        }
            //print("yes");
            //targetVelocity = new Vector2(0, this.vMovement);
            //this.rB.velocity = Vector3.SmoothDamp(this.rB.velocity, targetVelocity, ref this.velocity, 0.05
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
        MOVE_SPEED = 0;
    }

    public void unMoveble()
    {
        //this.enabled = false;
        //this.rB.velocity = new Vector2(0, 0);
        //this.rB.bodyType = RigidbodyType2D.Kinematic
        this.rB.bodyType = RigidbodyType2D.Static;
        this.isDied = true;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    public bool getIsOnground()
    {
        return this.isOnGroud;
    }

    public void setIsClimbing(bool state)
    {
        this.isClimbing = state;
    }
}