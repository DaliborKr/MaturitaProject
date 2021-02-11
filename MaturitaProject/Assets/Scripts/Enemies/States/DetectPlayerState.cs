using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerState : State
{
    public D_DetectPlayerState stateData;

    protected bool isInMinAgroRange;
    protected bool isInMaxAgroRange;

    public DetectPlayerState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_DetectPlayerState stateData) : base(stateMachine, enemy, animatorNameBool)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(0f);

        isInMinAgroRange = enemy.CheckMinAgroRange();
        isInMaxAgroRange = enemy.CheckMaxAgroRange();
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

        isInMinAgroRange = enemy.CheckMinAgroRange();
        isInMaxAgroRange = enemy.CheckMaxAgroRange();
    }
}
