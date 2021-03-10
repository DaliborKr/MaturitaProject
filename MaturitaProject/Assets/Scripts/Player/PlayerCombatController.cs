using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile1Prefab;

    private LineRenderer fireLinePlayer;

    [SerializeField]
    private bool combatEnabled;

    private bool gotInput;
    private bool isAtacking;
    private bool isMelee;
    private bool isTryingToFire;

    [SerializeField]
    private int damageNumberAttack1;

    [SerializeField]
    private float fireDelay;
    [SerializeField]
    private float inputTimer;
    [SerializeField]
    private float radiusAttack1;
    private float lastInputTime = Mathf.NegativeInfinity;
    private float lastFireTime = Mathf.NegativeInfinity;
    private float switchTime = 0.2f;
    private float lastTimeSwitched = Mathf.NegativeInfinity;

    [SerializeField]
    private Transform rangeCheckAttack1;
    [SerializeField]
    private Transform firePointPlayer;

    [SerializeField]
    private LayerMask whatIsDamageable;

    private Animator animator;

    private PlayerController pc;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("canAttack", combatEnabled);
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        fireLinePlayer = GameObject.Find("fireLinePlayer").GetComponent<LineRenderer>();
        isMelee = true;
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
        CheckNotDashingOrWallslidngWhileTryToFire();
    }

    private void CheckCombatInput()
    {
        if ((Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0) && !Input.GetMouseButtonDown(0) && Time.time >= lastTimeSwitched + switchTime)
        {
            lastTimeSwitched = Time.time;
            isMelee = !isMelee;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (isMelee)
            {
                if (combatEnabled)
                {
                    gotInput = true;
                    lastInputTime = Time.time;
                }
            }
            if (!isMelee && !pc.GetIsWallsliding())
            {
                TryToFire();
            }
        }
        
        if (Input.GetMouseButtonUp(0) && !isMelee && isTryingToFire )
        {
            isTryingToFire = false;
            animator.SetBool("isTryingToFire", isTryingToFire);
            animator.SetBool("isFiring", true);
            fireLinePlayer.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && isTryingToFire)
        {
            CancelTryToFire();
        }

        if (Input.GetMouseButtonUp(1) && isTryingToFire)
        {
            pc.EnableFlip();
            pc.FlipCharacter();
            pc.DisableFlip();
        }
        
    }

    private void CheckNotDashingOrWallslidngWhileTryToFire()
    {
        if (pc.GetIsDashing() && isTryingToFire)
        {
            CancelTryToFire();
        }
        if (pc.GetIsWallsliding() && isTryingToFire)
        {
            CancelTryToFire();
        }
    }

    private void CancelTryToFire()
    {
        isTryingToFire = false;
        animator.SetBool("isTryingToFire", isTryingToFire);
        fireLinePlayer.enabled = false;
        pc.EnableFlip();
    }

    private void TryToFire()
    {
        if (Time.time >= lastFireTime + fireDelay)
        {
            pc.DisableFlip();
            fireLinePlayer.enabled = true;
            isTryingToFire = true;
            animator.SetBool("isTryingToFire", isTryingToFire);
        }
    }

    private void Fire()
    {
        lastFireTime = Time.time;
        animator.SetBool("isFiring", false);
        Instantiate(projectile1Prefab, firePointPlayer.position, firePointPlayer.rotation);
        pc.EnableFlip();

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

        AttackDetails attackDetails = new AttackDetails(damageNumberAttack1, pc.transform.position, pc.GetFacingDir());

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
