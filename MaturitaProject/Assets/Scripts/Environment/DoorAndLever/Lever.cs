using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator animator;

    public bool isActivated;

    public Vector2 leverArea;

    private bool isPlayerInArea;

    public LayerMask whatIsPlayer;

    void Start()
    {
        isActivated = false;
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        ActivateLever();
    }

    private void FixedUpdate()
    {
        CheckPlayerInArea();
    }

    public void CheckPlayerInArea()
    {
        isPlayerInArea = Physics2D.OverlapBox(transform.position, leverArea, 0, whatIsPlayer);
    }

    public void ActivateLever()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInArea && !isActivated)
        {
            isActivated = true;
            animator.SetBool("isActivated", isActivated);
        }
        else if (Input.GetKeyDown(KeyCode.E) && isPlayerInArea && isActivated)
        {
            isActivated = false;
            animator.SetBool("isActivated", isActivated);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, leverArea);
    }
}
