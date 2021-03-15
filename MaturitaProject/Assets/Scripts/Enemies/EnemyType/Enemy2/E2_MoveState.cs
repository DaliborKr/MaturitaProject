using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_MoveState : MoveState
{
    private Enemy2 enemyType;

    public E2_MoveState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_MoveState stateData, Enemy2 enemyType) : base(stateMachine, enemy, animatorNameBool, stateData)
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

        if (isInMaxAgroRange)
        {
            stateMachine.ChangeState(enemyType.detectPlayerState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            enemyType.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemyType.idleState);
        }
        else if (enemyType.rb.velocity.x == 0 && stateMachine.currentState == enemyType.moveState)
        {
            enemyType.idleState.SetFlipAfterIdle(false);
            stateMachine.ChangeState(enemyType.idleState);
        }
        //Debug.Log("Move");
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
