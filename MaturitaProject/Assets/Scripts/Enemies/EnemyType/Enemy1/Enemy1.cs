using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public E1_IdleState idleState
    {
        get;
        private set;
    }

    public E1_MoveState moveState
    {
        get;
        private set;
    }

    public E1_DetectPlayerState detectPlayerState
    {
        get;
        private set;
    }

    public E1_MeleeAttackState meleeAttackState
    {
        get;
        private set;
    }

    public E1_RunState runState
    {
        get;
        private set;
    }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_DetectPlayerState detectPlayerStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    private D_RunState runStateData;

    [SerializeField]
    private Transform meleeAttackPoint;

    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(stateMachineEnemy, this, "move", moveStateData, this);
        idleState = new E1_IdleState(stateMachineEnemy, this, "idle", idleStateData, this);
        detectPlayerState = new E1_DetectPlayerState(stateMachineEnemy, this, "detectPlayer", detectPlayerStateData, this);
        meleeAttackState = new E1_MeleeAttackState(stateMachineEnemy, this, "meleeAttack", meleeAttackPoint, meleeAttackStateData, this);
        runState = new E1_RunState(stateMachineEnemy, this, "run", runStateData, this);

        stateMachineEnemy.Initialize(moveState);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPoint.position, meleeAttackStateData.attackRadius);
    }

}
