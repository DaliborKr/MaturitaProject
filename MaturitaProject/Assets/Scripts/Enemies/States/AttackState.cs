using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected Transform attackPoint;

    protected bool animationEnded;
    protected bool isInMinAgroRange;

    public AttackState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, Transform attackPoint) : base(stateMachine, enemy, animatorNameBool)
    {
        this.attackPoint = attackPoint;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isInMinAgroRange = enemy.CheckMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        animationEnded = false;
        enemy.animationToStates.attackState = this;
        enemy.SetVelocity(0f);
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

    public virtual void StartAttack()
    {

    }

    public virtual void FinishAttack()
    {
        animationEnded = true;
    }
}
