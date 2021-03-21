﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_FireAttackState : FireAttackState
{
    protected Enemy2 enemyType;

    public E2_FireAttackState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, Transform attackPoint, D_FireAttackState stateData, Enemy2 enemyType) : base(stateMachine, enemy, animatorNameBool, attackPoint, stateData)
    {
        this.enemyType = enemyType;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isDead)
        {
            stateMachine.ChangeState(enemyType.deadState);
        }

        if (animationEnded)
        {
            Debug.Log("Prehodil sem");
            if (isInMaxAgroRange)
            {
                stateMachine.ChangeState(enemyType.detectPlayerState);
            }
            else
            {
                stateMachine.ChangeState(enemyType.idleState);
            }
        }
        
        //Debug.Log("Fire");
        //Debug.Log("Ended anim: " + animationEnded);
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void StartAttack()
    {
        base.StartAttack();
    }
}