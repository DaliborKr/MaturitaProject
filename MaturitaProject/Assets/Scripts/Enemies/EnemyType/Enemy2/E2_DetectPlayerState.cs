using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_DetectPlayerState : DetectPlayerState
{
    private Enemy2 enemyType;

    public E2_DetectPlayerState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_DetectPlayerState stateData, Enemy2 enemyType) : base(stateMachine, enemy, animatorNameBool, stateData)
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
            }
        }

        if (isInMinAgroRange && Time.time > startTime + stateData.timeToTrigger)
        {
            stateMachine.ChangeState(enemyType.runState);
        }

        if (!isInMinAgroRange)
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
