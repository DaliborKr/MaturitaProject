using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDecetingLedge;
    protected bool isInMinAgroRange;
    protected bool isInMaxAgroRange;

    public MoveState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_MoveState stateData) : base(stateMachine, enemy, animatorNameBool)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isDecetingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        isInMinAgroRange = enemy.CheckMinAgroRange();
        isInMaxAgroRange = enemy.CheckMaxAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(stateData.movementSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
