using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    static public Vector2 player;
    public float movementSpeed = 5f;

    private float InputDirection;

    //jumping floats
    public float jumpForce = 8f;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    

    static public int availableJumps = 3;
    static public int availableJumpsLeft;

    
    private bool inverted = false;
    private bool canJump;
    

    //running and flipping 
    static public bool isRunning;
    private bool isFacingRight = true;
    static public bool isRunShooting;
    static public bool isStandShooting;
    static public bool hurt;

    public Rigidbody2D rb;
    private Animator animator;

    //ground check
    public float groundCheckCircle;
    public UnityEngine.Transform groundCheck;
    public LayerMask whatIsGrounded;
    private bool isGrounded;

    //Mask1 ability
    public float shieldCheckCircle;
    public GameObject Shield;
    public static bool activate = false;
    public static bool usable = true;
    public UnityEngine.Transform ShieldDetect;
    public static bool canAbsorb = false;
    public LayerMask whatIsBullet;
    public static float ShieldDurability = 100;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        availableJumpsLeft = availableJumps;

    }

    // Update is called once per frame
    void Update()
    {
        //���3
        Castle();

        //���1
        Mask1();
        Mask1Recover();
        if (usable)
        {
            Shield.SetActive(activate);
        }
        else
        {
            Shield.SetActive(false);
        }
       

        CheckInput();
        CheckMovementDirection();
        UpdateAnimation();
        player = transform.position;
        
        
        

        if (!inverted)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if ((rb.velocity.y > 0) && (!Input.GetButton("Jump")))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity -= Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if ((rb.velocity.y < 0) && (!Input.GetButton("Jump")))
            {
                rb.velocity -= Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {

        ApplyMovement();
        checkEnvironment();
        CheckIfCanJump();
       
  

    }


    private void UpdateAnimation()
    {
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isRunShooting", isRunShooting);
        animator.SetBool("isStandShooting", isStandShooting);
        animator.SetBool("hurt", hurt);
    }

    private void CheckInput()
    {
        InputDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }

    }

    private void Jump()
    {

        if (canJump)
        {

            if (!inverted)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
            }

            availableJumpsLeft--;
            isRunShooting = false;
        }
    }

    private void CheckIfCanJump()
    {

        if (!inverted)
        {
            if (isGrounded && rb.velocity.y <= 3)
            {
                availableJumpsLeft = availableJumps;

            }
            if ((availableJumpsLeft <= 0 || (!isGrounded && availableJumpsLeft == availableJumps)))
            {
                canJump = false;
            }
            else
            {
                canJump = true;
            }
        }
        else
        {
            if (isGrounded && rb.velocity.y >= -3)
            {
                availableJumpsLeft = availableJumps;

            }
            if ((availableJumpsLeft <= 0 || (!isGrounded && availableJumpsLeft == availableJumps)))
            {
                canJump = false;
            }
            else
            {
                canJump = true;
            }
        }
    }


    private void ApplyMovement()
    {

        rb.velocity = new Vector2(movementSpeed * InputDirection, rb.velocity.y);


    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180f, 0.0f);

    }

    private void CheckMovementDirection()
    {
        if(!inverted)
        {
            if (isFacingRight && (InputDirection < 0))
            {

                Flip();



            }
            else if (!isFacingRight && (InputDirection > 0))
            {
                Flip();
            }
        }
        else
        {
            if (isFacingRight && (InputDirection > 0))
            {

                Flip();



            }
            else if (!isFacingRight && (InputDirection < 0))
            {
                Flip();
            }
        }
        

        if (rb.velocity.x <= -0.5f || rb.velocity.x >= 0.5f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }


    }


    private void checkEnvironment()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckCircle, whatIsGrounded);
        canAbsorb = Physics2D.OverlapCircle(ShieldDetect.position, shieldCheckCircle, whatIsBullet)&&activate;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckCircle);
        Gizmos.DrawWireSphere(ShieldDetect.position, shieldCheckCircle);
    }

 

    private void Castle()
    {
        if (!inverted)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                
                rb.gravityScale = -1;
                //rb.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
                transform.Rotate(0.0f, 0.0f, -180f);
                inverted = true;
            }
        }
        if (inverted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                rb.gravityScale = 1;
                //rb.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                transform.Rotate(0.0f, 0.0f, 180f);
                inverted = false; ;
            }
        }


    }
    
    private void Mask1()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            activate = !activate;
            //Debug.Log(activate);
        }
    }

    private void Mask1Recover()
    {
        if (ShieldDurability <= 0)
        {
            usable = false;
        }
        else
        {
            usable = true;
        }
        if (ShieldDurability<100)
        {
            ShieldDurability += 1 * Time.deltaTime;
        }
        
    }

    //����Ч��
    private void onCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
        }
    }

 






}

   
