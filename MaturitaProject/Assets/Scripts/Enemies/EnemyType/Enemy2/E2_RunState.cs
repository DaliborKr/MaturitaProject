using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_RunState : RunState
{
    private Enemy2 enemyType;

    public E2_RunState(StateMachine stateMachine, Enemy enemy, string animatorNameBool, D_RunState stateData, Enemy2 enemyType) : base(stateMachine, enemy, animatorNameBool, stateData)
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

        if (isInMinAgroRange && (isDetectingWall || !isDetectingLedge))
        {
            stateMachine.ChangeState(enemyType.idleState);
        }

        else if (isInMinAgroRange)
        {
            if ((enemy.player.transform.position.x > enemy.aliveGameObject.transform.position.x && enemy.facingDir == 1) || (enemy.player.transform.position.x < enemy.aliveGameObject.transform.position.x && enemy.facingDir == -1))
            {
                enemy.Flip();
                enemy.rb.velocity *= -1;
            }
        }
        
        else if (isInMeleeAttackRange && !isInMinAgroRange)
        {
            stateMachine.ChangeState(enemyType.fireAttackState);
        }
        

        else if (isDetectingWall || !isDetectingLedge)
        {
            enemyType.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemyType.idleState);
        }

        else if (!isInMaxAgroRange)
        {
            stateMachine.ChangeState(enemyType.detectPlayerState);
        }
        //Debug.Log("Run");
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
