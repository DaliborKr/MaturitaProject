using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_IdleState : IdleState
{
    private Enemy2 enemyType;

    public E2_IdleState(StateMachine stateMachine, Enemy enemy, string animatorNameBool, D_IdleState stateData, Enemy2 enemyType) : base(stateMachine, enemy, animatorNameBool, stateData)
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
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemyType.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
