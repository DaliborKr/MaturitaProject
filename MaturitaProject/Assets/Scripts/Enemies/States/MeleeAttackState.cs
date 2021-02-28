using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected D_MeleeAttackState stateData;

    protected AttackDetails attackDetails;

    public MeleeAttackState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, Transform attackPoint, D_MeleeAttackState stateData) : base(stateMachine, enemy, animatorNameBool, attackPoint)
    {
        this.stateData = stateData;

        attackDetails = new AttackDetails(stateData.damageNumber, enemy.aliveGameObject.transform.position);
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

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPoint.position, stateData.attackRadius, stateData.whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            Debug.Log("melo by byt au");


            collider.transform.parent.SendMessage("GetDamage", attackDetails);
        }
    }
}
