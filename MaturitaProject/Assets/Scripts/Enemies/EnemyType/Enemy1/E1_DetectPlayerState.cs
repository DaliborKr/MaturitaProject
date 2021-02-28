using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DetectPlayerState : DetectPlayerState
{
    private Enemy1 enemyType;

    public E1_DetectPlayerState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_DetectPlayerState stateData, Enemy1 enemyType) : base(stateMachine, enemy, animatorNameBool, stateData)
    {
        this.enemyType = enemyType;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isInMeleeAttackRange)
        {
            stateMachine.ChangeState(enemyType.meleeAttackState);
        }

        if (!isInMaxAgroRange)
        {
            enemyType.idleState.SetFlipAfterIdle(false);
            stateMachine.ChangeState(enemyType.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
