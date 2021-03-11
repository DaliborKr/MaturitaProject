using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireAttackState : AttackState
{
    protected D_FireAttackState stateData;


    public FireAttackState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, Transform attackPoint, D_FireAttackState stateData) : base(stateMachine, enemy, animatorNameBool, attackPoint)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        enemy.animationToStates.attackState = this;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void StartAttack()
    {
        base.StartAttack();

        enemy.InstantiateProjectiles(stateData.projectilePrefab);
    }
}
