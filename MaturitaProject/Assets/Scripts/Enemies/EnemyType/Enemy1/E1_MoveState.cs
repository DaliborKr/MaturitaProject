using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{
    private Enemy1 enemyType;

    public E1_MoveState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_MoveState stateData, Enemy1 enemyType) : base(stateMachine, enemy, animatorNameBool, stateData)
    {
        this.enemyType = enemyType;
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

        if (isDetectingWall || !isDecetingLedge)
        {
            enemyType.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemyType.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
