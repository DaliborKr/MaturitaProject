using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DeadState : DeadState
{
    private Enemy1 enemyType;

    public E1_DeadState(StateMachine stateMachine, Enemy enemy, string animatorNameBool, Enemy1 enemyType) : base(stateMachine, enemy, animatorNameBool)
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

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
