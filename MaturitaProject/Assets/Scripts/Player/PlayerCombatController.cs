using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;

    private bool gotInput;
    private bool isAtacking;

    [SerializeField]
    private int damageNumberAttack1;

    [SerializeField]
    private float inputTimer;
    [SerializeField]
    private float radiusAttack1;
    private float lastInputTime = Mathf.NegativeInfinity;

    [SerializeField]
    private Transform rangeCheckAttack1;

    [SerializeField]
    private LayerMask whatIsDamageable;

    private Animator animator;

    private PlayerController pc;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("canAttack", combatEnabled);
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
    }

    private void CheckCombatInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (combatEnabled)
            {
                gotInput = true;
                lastInputTime = Time.time;
            }
        }
    }

    private void CheckAttacks()
    {
        if (gotInput && !pc.GetIsWallsliding())
        {
            if (!isAtacking)
            {
                gotInput = false;
                isAtacking = true;
                animator.SetBool("attack1", true);
                animator.SetBool("isAttacking", isAtacking);
            }
        }

        if (Time.time >= lastInputTime + inputTimer)
        {
            gotInput = false;
        }
    }

    private void CheckAttackHitbox()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(rangeCheckAttack1.position, radiusAttack1, whatIsDamageable);

        AttackDetails attackDetails = new AttackDetails(damageNumberAttack1, pc.GetFacingDir());

        foreach (Collider2D collider in objects)
        {
            Debug.Log("melo by byt au");
            collider.transform.parent.SendMessage("GetDamage", attackDetails);
        }
    }

    private void FinishAttack1()
    {
        isAtacking = false;
        animator.SetBool("attack1", false);
        animator.SetBool("isAttacking", isAtacking);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rangeCheckAttack1.position, radiusAttack1);
    }

    /*
    private bool isInMeleeRange;
    private bool gotInput;

    private float lastInputTime;

    private PlayerController pc;

    public Transform attackRangeCheck;

    public int damageNumber = 60;

    public float attackRadius = 2;

    public LayerMask whatIsDamageable;

    public void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void Update()
    {
        CheckInput();
        //CheckIsAttemptingToAttack();
    }

    public void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastInputTime = Time.time;
            gotInput = true;

            CheckIsInAttackRange();
        }
    }

    public void CheckIsAttemptingToAttack()
    {
        if (gotInput)
        {
            gotInput = false;
            
        }
    }

    public void CheckIsInAttackRange()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(attackRangeCheck.position, attackRadius, whatIsDamageable);

        AttackDetails attackDetails = new AttackDetails(damageNumber, pc.GetFacingDir());

        foreach (Collider2D collider in objects){
            Debug.Log("melo by byt au");
            collider.transform.parent.SendMessage("GetDamage", attackDetails);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackRangeCheck.position, attackRadius);
    }
    */
}
