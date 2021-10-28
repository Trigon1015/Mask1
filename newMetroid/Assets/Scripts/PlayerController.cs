using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    static public Vector2 player;
    public float movementSpeed = 5f;
    public GameObject Firepoint;
    private float InputDirection;
    float countdown = 1;
    float countSqaut = 1;

    //jumping floats
    public float jumpForce = 8f;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    

    static public int availableJumps = 1;
    static public int availableJumpsLeft;

    
    private bool inverted = false;
    private bool canJump;
    

    //running and flipping 
    static public bool isRunning;
    private bool isFacingRight = true;
    static public bool isRunShooting;
    static public bool isStandShooting;
    static public bool hurt;
    static public bool isCrouching;
    static public bool isShootingUp;
    static public bool hurtplayer;
    static public bool isCrouchShooting;
    static public float HurtTime = 0;
    public Rigidbody2D rb;
    private Animator animator;

    //collider manage
    public CapsuleCollider2D capsuleCollider;
    public bool Cc = false;
    public float ColliderSizeX = 0.1f;
    public float ColliderSizeY = 0.4f;

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
        capsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        
        //面具3
        Castle();
        
        //面具1
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
        AnimationContoller();




    }


    private void UpdateAnimation()
    {
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isRunShooting", isRunShooting);
        animator.SetBool("isStandShooting", isStandShooting);
        animator.SetBool("hurt", hurt);
        animator.SetBool("isCrouching", isCrouching);
        animator.SetBool("isShootingUp", isShootingUp);
        animator.SetBool("isCrouchShooting", isCrouchShooting);
        
    }
    int i = 1;
    private void CheckInput()
    {
       
        InputDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            isCrouching = true;
            
        }



        if (Input.GetKeyDown(KeyCode.W))
        {
            if(isCrouching)
            {
                isCrouching = false;
            }
            else
            {
                isShootingUp = true;
                
            }

        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            isCrouching = false;

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isCrouching = false;
            
        }
        if (isCrouching)
        {
            movementSpeed = 0;
            
        }
        else
        {
            movementSpeed = 5f;
            Cc = false;
        }

        if (isCrouching && !Cc)
        {
            capsuleCollider.size = new Vector2(ColliderSizeX, ColliderSizeY * 0.7f);
            Cc = true;
        }
        if(!isCrouching)
        {
            capsuleCollider.size = new Vector2(ColliderSizeX, ColliderSizeY);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            i++;
            Debug.Log(i);
            if (i%2==0)
            {
                transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            }
            if (i%2==1)
            {
                transform.localScale = new Vector3(5f, 5f, 5f);
            }
            
            
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
            isRunShooting = false;
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
    //private void supertime()
    //{
    //    if (PlayerController.hurtplayer == true)
    //    {
    //        PlayerController.HurtTime += 1 * Time.deltaTime;
    //        if (PlayerController.HurtTime >= 2)
    //        {
    //            PlayerController.hurtplayer = false;
    //            PlayerController.HurtTime = 0;
    //        }
    //    }
    //}
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

    private void AnimationContoller()
    {
        
        if (isRunning)
        {
            isStandShooting = false;
        }
        if(isStandShooting)
        {
            countdown -= Time.deltaTime;
            //Debug.Log(countdown);
        }
        
        if (countdown <=0)
        {
            isStandShooting = false;
            countdown = 1;
        }

        if (!isCrouching)
        {
            isCrouchShooting = false;
        }

        if (isCrouchShooting)
        {
            countSqaut-= Time.deltaTime;
            
        }

        if (countSqaut <= 0)
        {
            isCrouchShooting = false;
            countdown = 1;
        }

        






    }









}

   
