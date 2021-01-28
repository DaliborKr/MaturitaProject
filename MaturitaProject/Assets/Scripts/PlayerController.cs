using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementInputValue;

    public int currentNumberOfJumps;

    private Rigidbody2D rb;

    private bool isFacingRight = true;
    private bool canJump;
    public bool isOnGround;


    public float speedMovement = 10.0f;
    public float jumpForce = 16.0f;
    public float groundCheckRadius;

    public int maxNumberOfJumps = 1;

    public Transform groundCheck;

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
    }

    private void RealizeMovement()
    {
        rb.velocity = new Vector2(speedMovement * movementInputValue, rb.velocity.y);
    }

    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            currentNumberOfJumps--;
        }
    }

    private void CheckCanJump()
    {
        if (isOnGround && rb.velocity.y <= 0)
        {
            currentNumberOfJumps = maxNumberOfJumps;
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
        transform.Rotate(0.0f, 180.0f, 0.0f);
        isFacingRight = !isFacingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
