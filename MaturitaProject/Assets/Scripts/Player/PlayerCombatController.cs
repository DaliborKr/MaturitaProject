using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
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
}
