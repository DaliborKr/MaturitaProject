using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public string currentLevelName;

    private float movementInputValue;
    private float dashingTimeLeft;
    private float lastDashTime = -10000000;
    private float jumpDelayLeft;

    private int currentNumberOfJumps;
    private int facingDir;
    private int inputDir;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isFacingRight = true;
    private bool canJump;
    private bool isOnGround;
    private bool wasOnGround;
    private bool isTouchingWall;
    private bool isWallsliding;
    private bool flippedInAir;
    private bool iswallJumping;
    private bool isDashing;
    private bool canMove;
    private bool canFlip;
    private bool isFirstDashInAir;
    private bool isAttemptingToJump;
    private bool isWalking;
    private bool cameraShakeDone;

    public float speedMovement = 10.0f;
    public float jumpForce = 16.0f;
    public float groundCheckRadius;
    public float wallSlideSpeed;
    public float wallCheckDistance;
    public float forceInAir;
    public float wallHopForce;
    public float wallJumpForce;
    public float wallJumpForceStraight;
    public float dashSpeed;
    public float dashingTime;
    public float dashCooldown;
    public float jumpDelay;

    public bool dashAvaiable;
    public bool wallJumpAvaiable;

    public int maxNumberOfJumps = 1;

    public Vector2 wallHopDir;
    public Vector2 wallJumpDir;

    public Vector3 currentSpawnPos;

    public Transform groundCheck;
    public Transform wallCheck;

    public LayerMask isGround;

    public CameraShake cameraShake;

    private PauseMenu pauseMenu;

    void Start()
    {
        currentLevelName = SceneManager.GetActiveScene().name;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pauseMenu = GameObject.Find("PauseManager").GetComponent<PauseMenu>();
        currentNumberOfJumps = maxNumberOfJumps;
        dashingTimeLeft = dashingTime;
        canFlip = true;
        canMove = true;
    }

    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        CheckCanJump();
        CheckWallSliding();
        CheckInputDirection();
        JumpCheck();
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        RealizeMovement();
        CheckEnvironment();
        DashCheck();
    }

    private void CheckInput()
    {
        if (!pauseMenu.isActivated)
        {
            movementInputValue = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                AttemptToJump();
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (Time.time > (lastDashTime + dashCooldown))
                {
                    Dash();
                }
            }
        }
    }

    private void UpdateAnimations()
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isOnGround);
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isWallSliding", isWallsliding);
    }

    private void CheckEnvironment()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, isGround);
    }

    private void RealizeMovement()
    {
        if (canMove)
        {
            if (isOnGround)
            {
                rb.velocity = new Vector2(speedMovement * movementInputValue, rb.velocity.y);
            }
            else if (!isOnGround && !isWallsliding && movementInputValue != 0)
            {
                Vector2 newForce = new Vector2(forceInAir * movementInputValue, 0);
                rb.AddForce(newForce);

                if (flippedInAir && !iswallJumping)
                {
                    rb.velocity = new Vector2(movementInputValue, rb.velocity.y);
                }


                if (Mathf.Abs(rb.velocity.x) > speedMovement)
                {
                    rb.velocity = new Vector2(speedMovement * movementInputValue, rb.velocity.y);
                }
                flippedInAir = false;
                iswallJumping = false;
            }
            if (isWallsliding)
            {
                if (rb.velocity.y < -wallSlideSpeed)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
                }

            }
        }
    }

    private void AttemptToJump()
    {
        isAttemptingToJump = true;
        jumpDelayLeft = jumpDelay;
    }

    private void JumpCheck()
    {
        if (isAttemptingToJump)
        {
            if (jumpDelayLeft > 0)
            {
                Jump();
                jumpDelayLeft -= Time.deltaTime;
            }
            else
            {
                isAttemptingToJump = false;
            }
        }

    }

    private void Jump()
    {
        if (canJump && !isWallsliding)
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            currentNumberOfJumps--;
            isAttemptingToJump = false;
        }
        
        else if (canJump && isWallsliding && movementInputValue == 0)
        {
            Vector2 newWallHopForce = new Vector2(wallHopDir.x * wallHopForce * -facingDir , wallHopDir.y * wallHopForce);
            rb.AddForce(newWallHopForce, ForceMode2D.Impulse);
            FlipWallJumpingCharacter();

            isWallsliding = false;
            currentNumberOfJumps--;
            isAttemptingToJump = false;
        }
        else if (canJump && isWallsliding  && movementInputValue != 0 && wallJumpAvaiable)
        {
            
            if (facingDir == inputDir)
            {
                rb.velocity = new Vector2(rb.velocity.x, wallJumpForceStraight);
                Vector2 newWallJumpForce = new Vector2(50 * -facingDir, 0);
                rb.AddForce(newWallJumpForce, ForceMode2D.Impulse);
                isAttemptingToJump = false;
            }
            else
            {
                //iswallJumping = true;
                rb.velocity = new Vector2(wallJumpForce * -facingDir, wallJumpForceStraight);
                FlipWallJumpingCharacter();
                iswallJumping = true;
                isAttemptingToJump = false;
            }

            isWallsliding = false;
            currentNumberOfJumps --;
        }
        
    }

    private void Dash()
    {
        if (isFirstDashInAir && dashAvaiable)
        {
            isDashing = true;
            dashingTimeLeft = dashingTime;
            lastDashTime = Time.time;
        }
    }

    private void DashCheck()
    {
        if (isDashing)
        {
            if (dashingTimeLeft > 0 && isFirstDashInAir && !isTouchingWall)
            {
                canMove = false;
                canFlip = false;
                rb.velocity = new Vector2(dashSpeed * facingDir, 0);
                dashingTimeLeft -= Time.deltaTime;
            }

            if (dashingTimeLeft <= 0 || isTouchingWall)
            {
                isDashing = false;
                canMove = true;
                canFlip = true;
                isFirstDashInAir = false;
                if (!isOnGround && !isWallsliding)
                {
                    Vector2 newForce = new Vector2(forceInAir * facingDir, 0);
                    rb.AddForce(newForce);

                    if (flippedInAir && !iswallJumping)
                    {
                        rb.velocity = new Vector2(movementInputValue, rb.velocity.y);

                    }


                    if (Mathf.Abs(rb.velocity.x) > speedMovement)
                    {
                        rb.velocity = new Vector2(speedMovement * facingDir, rb.velocity.y);
                    }
                    flippedInAir = false;
                    iswallJumping = false;
                }
            }
            
        }
    }
    private void CheckInputDirection()
    {
        if (isFacingRight)
        {
            facingDir = 1;
        }
        else
        {
            facingDir = -1;
        }

        if (movementInputValue > 0)
        {
            inputDir = 1;
        }
        else if (movementInputValue < 0)
        {
            inputDir = -1;
        }
        else
        {
            inputDir = 0;
        }
    }

    public int GetFacingDir()
    {
        return facingDir;
    }

    private void CheckCanJump()
    {
        if ((isOnGround && rb.velocity.y <= 0) || isWallsliding)
        {
            if (!cameraShakeDone)
            {
                //cameraShake.cameraShaking = true;
                cameraShakeDone = true;
            }
            currentNumberOfJumps = maxNumberOfJumps;
            isFirstDashInAir = true;
            wasOnGround = true;
            
        }
        else if(wasOnGround && rb.velocity.y <= 0)
        {                       
            currentNumberOfJumps--;
            wasOnGround = false;
            cameraShakeDone = false;
        }
        else 
        { 
            wasOnGround = false;
            cameraShakeDone = false;
        }
        
        if (currentNumberOfJumps <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    private void CheckWallSliding()
    {
        if (isTouchingWall && !isOnGround && (rb.velocity.x < 0.00001 && rb.velocity.x > -0.00001))
        {
            isWallsliding = true;
        }
        else
        {
            isWallsliding = false;
        }
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && movementInputValue < 0.0f)
        {
            FlipCharacter();
        }
        else if (!isFacingRight && movementInputValue > 0.0f)
        {
            FlipCharacter();
        }

        if (rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    public void FlipCharacter()
    {
        if (canFlip)
        {
            if (!isWallsliding)
            {
                transform.Rotate(0.0f, 180.0f, 0.0f);
                isFacingRight = !isFacingRight;

                if (!isOnGround)
                {
                    flippedInAir = true;
                }
                else
                {
                    flippedInAir = false;
                }
            }
        }
    }

    public void EnableFlip()
    {
        canFlip = true;
    }

    public void DisableFlip()
    {
        canFlip = false;
    }

    public bool GetIsWallsliding()
    {
        return isWallsliding;
    }

    public bool GetIsDashing()
    {
        return isDashing;
    }

    private void FlipWallJumpingCharacter()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);
        isFacingRight = !isFacingRight;
    }

    public void AddForceWhenHitted(bool toRight, Vector2 hitForce)
    {
        isOnGround = false;
        currentNumberOfJumps = maxNumberOfJumps;
        currentNumberOfJumps--;

        if (toRight)
        {
            rb.velocity = new Vector2(hitForce.x * 1, hitForce.y);
        }
        else
        {
            rb.velocity = new Vector2(hitForce.x * -1, hitForce.y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
