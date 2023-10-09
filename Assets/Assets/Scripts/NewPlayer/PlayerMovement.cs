using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, Iplatform
{
    [Header("Movement")] public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
  
    public float airMultiplier;
    bool readyToJump;

    

    [Header("Keybinds")] public KeyCode jumpKey = KeyCode.Space;
    
    [Header("Ground Check")] public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    private bool canDoubleJump;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    private Vector3 moveInput;

    [SerializeField] Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isrunning = animator.GetBool("isRuning");
        bool RunKey=Input.GetKey(KeyCode.R);
        bool isCrouch = animator.GetBool("isCrouch");
        bool CrouchKey  =Input.GetKey(KeyCode.C);
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
         moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        MyInput();
        SpeedControl();

        // handle The drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
        
        if (moveInput.magnitude > 0 && grounded)
        { 
            // start walking
            animator.SetBool("isMoving", true);
            moveSpeed = 4F; 
//            SoundManager.Instance.PlayWalkSound();
        }
        else if (moveInput.magnitude > 0 && !grounded)
        { 
            // stop walking if the player walking and not grounded
            animator.SetBool("isMoving", false);
            
        }
        else
        {
            //stop walking
            animator.SetBool("isMoving", false);
        }
        //  crouching 
        if (!isCrouch &&  CrouchKey  && moveInput.magnitude > 0 )
        {   //check if the player crouching and press the crouch key
            animator.SetBool("isCrouch", true);
            animator.SetBool("isStanding", false);
            moveSpeed = 2f;
            Debug.Log("crouching now");
        }
        if (isCrouch &&  CrouchKey)
        {   //check if the player crouching and press the crouch key
            animator.SetBool("isCrouch", true);
            animator.SetBool("isStanding", false);
            moveSpeed = 2f;
            Debug.Log("crouching now");
        }
        if (isCrouch && (moveInput.magnitude == 0 || !CrouchKey ))
        {
            //check if the player not Crouch and (he is not moving OR not press the Crouch key)
            //stop Running
           
            animator.SetBool("isCrouch", false);
            animator.SetBool("isStanding", true);
            moveSpeed = 5f;
        
        }
        //calculate movement direction

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        // running status 
        if (!isrunning &&  RunKey)
        {   //check if the player running and press the run key
            animator.SetBool("isRuning", true);
            moveSpeed = 7f;
            animator.SetBool("isMoving", false);
           
            Debug.Log("runing now");
            SoundManager.Instance.PlayWalkSound();
        }
        if (isrunning && (moveInput.magnitude == 0 || !RunKey ))
        {
            //check if the player not running and (he is moving OR not press the run key)
            //stop Running
            moveSpeed = 5f;
            animator.SetBool("isRuning", false);
        
        }
        // player on ground
        if (grounded)
        {
            readyToJump = true;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            animator.SetBool("isFalling", false);
            canDoubleJump = true;

        }
        // in air
        else if (!grounded )
        {   
            animator.SetBool("isFalling", true);
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            
        } else if (!grounded && canDoubleJump && Input.GetKeyDown(jumpKey)  )
        {   
            animator.SetBool("isJump", true);
            animator.SetBool("isFalling", true);
            
            canDoubleJump = false;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        
        if (Input.GetKeyDown(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            animator.SetBool("isJump", true);
            SoundManager.Instance.PlayJumpSound();
            Debug.Log("jumping");
            Jump();

          //  Invoke(nameof(ResetJump), jumpCooldown);
        } else
        {
            animator.SetBool("isJump", false);
        }
    }

  

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
   
}

