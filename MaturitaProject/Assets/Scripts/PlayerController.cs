using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementInputValue;

    public int currentNumberOfJumps;
    private int facingDir;
    private int inputDir;

    private Rigidbody2D rb;

    private bool isFacingRight = true;
    private bool canJump;
    public bool isOnGround;
    private bool wasOnGround;
    private bool isTouchingWall;
    public bool isWallsliding;
    private bool flippedInAir;
    private bool iswallJumping;

    public float speedMovement = 10.0f;
    public float jumpForce = 16.0f;
    public float groundCheckRadius;
    public float wallSlideSpeed;
    public float wallCheckDistance;
    public float forceInAir;
    public float wallHopForce;
    public float wallJumpForce;
    public float wallJumpForceStraight;
    

    public int maxNumberOfJumps = 1;

    public Vector2 wallHopDir;
    public Vector2 wallJumpDir;

    public Transform groundCheck;
    public Transform wallCheck;

    public LayerMask isGround;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentNumberOfJumps = maxNumberOfJumps;
    }

    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        CheckCanJump();
        CheckWallSliding();
        CheckInputDirection();
    }

    private void FixedUpdate()
    {
        RealizeMovement();
        CheckEnvironment();
    }

    private void CheckInput()
    {
        movementInputValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void CheckEnvironment()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, isGround);
    }

    private void RealizeMovement()
    {
        if (isOnGround)
        {
            rb.velocity = new Vector2(speedMovement * movementInputValue, rb.velocity.y);
        }
        else if (!isOnGround && !isWallsliding  && movementInputValue != 0)
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

    private void Jump()
    {
        if (canJump && !isWallsliding)
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            currentNumberOfJumps--;
        }
        
        else if (canJump && isWallsliding && movementInputValue == 0)
        {
            Vector2 newWallHopForce = new Vector2(wallHopDir.x * wallHopForce * -facingDir , wallHopDir.y * wallHopForce);
            rb.AddForce(newWallHopForce, ForceMode2D.Impulse);

            isWallsliding = false;
            currentNumberOfJumps--;    
        }
        else if (canJump && isWallsliding  && movementInputValue != 0)
        {
            
            if (facingDir == inputDir)
            {
                rb.velocity = new Vector2(rb.velocity.x, wallJumpForceStraight);
                Vector2 newWallJumpForce = new Vector2(180 * -facingDir, 0);
                rb.AddForce(newWallJumpForce, ForceMode2D.Impulse);
            }
            else
            {
                iswallJumping = true;
                rb.velocity = new Vector2(wallJumpForce * -facingDir, wallJumpForceStraight);
            }

            isWallsliding = false;
            currentNumberOfJumps --;
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
    private void CheckCanJump()
    {
        if ((isOnGround && rb.velocity.y <= 0) || isWallsliding)
        {
            currentNumberOfJumps = maxNumberOfJumps;
            wasOnGround = true;           
        }
        else if(wasOnGround && rb.velocity.y <= 0)
        {                       
            currentNumberOfJumps--;
            wasOnGround = false;
        }
        else 
        { 
            wasOnGround = false; 
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
        if (isTouchingWall && !isOnGround && rb.velocity.x == 0)
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
    }

    private void FlipCharacter()
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
