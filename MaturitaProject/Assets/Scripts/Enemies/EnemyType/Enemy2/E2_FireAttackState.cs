using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_FireAttackState : FireAttackState
{
    protected Enemy2 enemyType;

    public E2_FireAttackState(StateMachine stateMachine, Enemy enemy, string animatorNameBool, Transform attackPoint, D_FireAttackState stateData, Enemy2 enemyType) : base(stateMachine, enemy, animatorNameBool, attackPoint, stateData)
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
            if (isInMaxAgroRange)
            {
                stateMachine.ChangeState(enemyType.detectPlayerState);
            }
            else
            {
                stateMachine.ChangeState(enemyType.idleState);
            }
        }      
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
