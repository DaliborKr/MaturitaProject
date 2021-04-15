using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    protected D_RunState stateData;

    protected bool isInMinAgroRange;
    protected bool isInMaxAgroRange;
    protected bool isInMeleeAttackRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;

    public RunState(StateMachine stateMachine, Enemy enemy, string animatorNameBool, D_RunState stateData) : base(stateMachine, enemy, animatorNameBool)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isInMinAgroRange = enemy.CheckMinAgroRange();
        isInMaxAgroRange = enemy.CheckMaxAgroRange();
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
        isInMeleeAttackRange = enemy.CheckPlayerInMeleeAttackRange();
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(stateData.runSpeed);
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
