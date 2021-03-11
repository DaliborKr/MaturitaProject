﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_RunState : RunState
{
    private Enemy2 enemyType;

    public E2_RunState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_RunState stateData, Enemy2 enemyType) : base(stateMachine, enemy, animatorNameBool, stateData)
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isDead)
        {
            stateMachine.ChangeState(enemyType.deadState);
        }

        if (isInMinAgroRange)
        {
            if ((enemy.player.transform.position.x < enemy.aliveGameObject.transform.position.x && enemy.facingDir == 1) || (enemy.player.transform.position.x > enemy.aliveGameObject.transform.position.x && enemy.facingDir == -1))
            {
                enemy.Flip();
                enemy.rb.velocity *= -1;
            }
        }
        if (isInMeleeAttackRange)
        {
            stateMachine.ChangeState(enemyType.fireAttackState);
        }

        if (isDetectingWall || !isDetectingLedge)
        {
            enemyType.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemyType.idleState);
        }

        if (!isInMaxAgroRange)
        {
            stateMachine.ChangeState(enemyType.detectPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
