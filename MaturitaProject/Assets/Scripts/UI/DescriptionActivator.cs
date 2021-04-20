using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionActivator : MonoBehaviour
{
    private bool isPlayerIn;
    private bool wasPlayerIn;
    private Animator animator;
    public Vector2 descArea;
    public LayerMask whatIsPlayerDesc;

    void Start()
    {
        animator = GetComponent<Animator>();
        isPlayerIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        ManageText();
    }

    private void FixedUpdate()
    {
        CheckPlayerIn();
    }

    public void CheckPlayerIn()
    {
        isPlayerIn = Physics2D.OverlapBox(transform.position, descArea, 0, whatIsPlayerDesc);
    }

    public void ManageText()
    {
        if (isPlayerIn && !wasPlayerIn)
        {
            animator.SetBool("isPlayerIn", isPlayerIn);
            wasPlayerIn = true;
        }
        else if(!isPlayerIn && wasPlayerIn)
        {
            animator.SetBool("isPlayerIn", isPlayerIn);
            wasPlayerIn = false;
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 vectorHelp = new Vector3(descArea.x, descArea.y, 1.0f);
        Gizmos.DrawWireCube(transform.position, vectorHelp);
    }
}
