using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public bool fireAvaiable;
    public int projectileType;

    [SerializeField]
    private GameObject[] projectilePrefabs;

    private LineRenderer fireLinePlayer;

    private FireLinePlayer fireLinePlayerScript;

    [SerializeField]
    private bool combatEnabled;

    private bool gotInput;
    private bool isAtacking;
    public bool isMelee;
    private bool isTryingToFire;

    public int damageNumberAttack1;

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

    private PauseMenu pauseMenu;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("canAttack", combatEnabled);
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        fireLinePlayer = GameObject.Find("fireLinePlayer").GetComponent<LineRenderer>();
        pauseMenu = GameObject.Find("PauseManager").GetComponent<PauseMenu>();
        fireLinePlayerScript = GameObject.Find("fireLinePlayer").GetComponent<FireLinePlayer>();
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
        if (!pauseMenu.isActivated)
        {
            if ((Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0) && !Input.GetMouseButtonDown(0) && Time.time >= lastTimeSwitched + switchTime && fireAvaiable)
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
                        //lastInputTime = Time.time;
                    }
                }
                if (!isMelee && !pc.GetIsWallsliding())
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = false;
                    TryToFire();
                }
            }

            if (Input.GetMouseButtonUp(0) && !isMelee && isTryingToFire)
            {
                isTryingToFire = false;
                animator.SetBool("isTryingToFire", isTryingToFire);
                animator.SetBool("isFiring", true);
                fireLinePlayer.enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.Q) && isTryingToFire)
            {
                CancelTryToFire();
            }

            if (Input.GetMouseButtonUp(1) && isTryingToFire)
            {
                pc.EnableFlip();              
                pc.FlipCharacter();
                fireLinePlayerScript.FlipReaction();
                pc.DisableFlip();
            }
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
        Cursor.lockState = CursorLockMode.Locked;
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

        Instantiate(projectilePrefabs[projectileType], firePointPlayer.position, firePointPlayer.rotation);

        pc.EnableFlip();  
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CheckAttacks()
    {
        if (gotInput && !pc.GetIsWallsliding())
        {
            if (!isAtacking && Time.time >= lastInputTime + inputTimer)
            {
                lastInputTime = Time.time;
                gotInput = false;
                isAtacking = true;
                animator.SetBool("attack1", true);
                animator.SetBool("isAttacking", isAtacking);
            }
            else if (!isAtacking && Time.time < lastInputTime + inputTimer)
            {
                gotInput = false;
            }
        }
    }

    private void CheckAttackHitbox()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(rangeCheckAttack1.position, radiusAttack1, whatIsDamageable);

        AttackDetails attackDetails = new AttackDetails(damageNumberAttack1, pc.transform.position, pc.GetFacingDir());

        foreach (Collider2D collider in objects)
        {
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
}
