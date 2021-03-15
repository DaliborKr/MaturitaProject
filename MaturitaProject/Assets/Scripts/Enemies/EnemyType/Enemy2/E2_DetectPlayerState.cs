using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_DetectPlayerState : DetectPlayerState
{
    private Enemy2 enemyType;

    protected bool isDetectingBehindWall;
    protected bool isDetectingBehindLedge;

    public E2_DetectPlayerState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_DetectPlayerState stateData, Enemy2 enemyType) : base(stateMachine, enemy, animatorNameBool, stateData)
    {
        this.enemyType = enemyType;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isDetectingBehindLedge = enemyType.CheckLedgeBehind();
        isDetectingBehindWall = enemyType.CheckWallBehind();
        //Debug.Log("ledge behind:" + isDetectingBehindLedge);
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

        if (isDead)
        {
            stateMachine.ChangeState(enemyType.deadState);
        }

        if (isInMaxAgroRange)
        {
            if ((enemy.player.transform.position.x < enemy.aliveGameObject.transform.position.x && enemy.facingDir == 1) || (enemy.player.transform.position.x > enemy.aliveGameObject.transform.position.x && enemy.facingDir == -1))
            {
                enemy.Flip();
            }
        }

        if (isInMinAgroRange)
        {
            if ((enemy.player.transform.position.x > enemy.aliveGameObject.transform.position.x && enemy.facingDir == 1) || (enemy.player.transform.position.x < enemy.aliveGameObject.transform.position.x && enemy.facingDir == -1))
            {
                enemy.Flip();
            }
        }

        if ((!isDetectingBehindLedge && isDetectingLedge) || (isDetectingBehindLedge && !isDetectingLedge) && isInMinAgroRange)
        {
            stateMachine.ChangeState(enemyType.fireAttackState);
        }
        else if (isInMinAgroRange)
        {
            stateMachine.ChangeState(enemyType.runState);
        }

        else if (isInMeleeAttackRange && !isInMinAgroRange)
        {
            stateMachine.ChangeState(enemyType.fireAttackState);
        }

        else if (isInMaxAgroRange && Time.time > startTime + stateData.timeToTrigger)
        {
            stateMachine.ChangeState(enemyType.runState);
        }

        else if (!isInMaxAgroRange && !isInMinAgroRange)
        {
            enemyType.idleState.SetFlipAfterIdle(false);
            stateMachine.ChangeState(enemyType.idleState);
        }
        
        //Debug.Log("Detect");
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
