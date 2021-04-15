using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerState : State
{
    public D_DetectPlayerState stateData;

    protected bool isInMinAgroRange;
    protected bool isInMaxAgroRange;
    protected bool isInMeleeAttackRange;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;

    public DetectPlayerState(StateMachine stateMachine, Enemy enemy, string animatorNameBool, D_DetectPlayerState stateData) : base(stateMachine, enemy, animatorNameBool)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isInMinAgroRange = enemy.CheckMinAgroRange();
        isInMaxAgroRange = enemy.CheckMaxAgroRange();
        isInMeleeAttackRange = enemy.CheckPlayerInMeleeAttackRange();
        isDetectingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
