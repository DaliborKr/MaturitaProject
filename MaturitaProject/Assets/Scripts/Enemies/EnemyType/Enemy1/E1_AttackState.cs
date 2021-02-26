using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_AttackState : AttackState
{
    private Enemy1 enemyType;

    public E1_AttackState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_AttackState stateData, Enemy1 enemyType) : base(stateMachine, enemy, animatorNameBool, stateData)
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
