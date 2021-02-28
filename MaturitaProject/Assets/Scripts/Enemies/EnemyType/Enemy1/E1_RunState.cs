using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_RunState : RunState
{
    private Enemy1 enemyType;

    public E1_RunState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_RunState stateData, Enemy1 enemyType) : base(stateMachine, enemy, animatorNameBool, stateData)
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
            stateMachine.ChangeState(enemyType.meleeAttackState);
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
