using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeleeAttackState : MeleeAttackState
{
    protected Enemy1 enemyType;

    public E1_MeleeAttackState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, Transform attackPoint, D_MeleeAttackState stateData, Enemy1 enemyType) : base(stateMachine, enemy, animatorNameBool, attackPoint, stateData)
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

        if (animationEnded)
        {
            if (isInMinAgroRange)
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
