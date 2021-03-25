using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public E2_IdleState idleState
    {
        get;
        private set;
    }

    public E2_MoveState moveState
    {
        get;
        private set;
    }

    public E2_DetectPlayerState detectPlayerState
    {
        get;
        private set;
    }

    public E2_RunState runState
    {
        get;
        private set;
    }

    public E2_DeadState deadState
    {
        get;
        private set;
    }

    public E2_FireAttackState fireAttackState
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
    private D_RunState runStateData;
    [SerializeField]
    private D_FireAttackState fireAttackStateData;

    [SerializeField]
    private Transform ledgeBehindCheck;
    [SerializeField]
    private Transform wallBehindCheck;

    public override void Start()
    {
        base.Start();

        moveState = new E2_MoveState(stateMachineEnemy, this, "move", moveStateData, this);
        idleState = new E2_IdleState(stateMachineEnemy, this, "idle", idleStateData, this);
        detectPlayerState = new E2_DetectPlayerState(stateMachineEnemy, this, "detectPlayer", detectPlayerStateData, this);
        runState = new E2_RunState(stateMachineEnemy, this, "run", runStateData, this);
        deadState = new E2_DeadState(stateMachineEnemy, this, "dead", this);
        fireAttackState = new E2_FireAttackState(stateMachineEnemy, this, "fire", attackPoint, fireAttackStateData, this);

        stateMachineEnemy.Initialize(moveState);
    }

    public override void Update()
    {
        base.Update();
    }

    public virtual bool CheckWallBehind()
    {
        return Physics2D.Raycast(wallBehindCheck.position, aliveGameObject.transform.right, enemyData.wallCheckDist, enemyData.whatIsGround);
    }

    public virtual bool CheckLedgeBehind()
    {
        return Physics2D.Raycast(ledgeBehindCheck.position, Vector2.down, enemyData.ledgeCheckDist, enemyData.whatIsGround);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawLine(wallBehindCheck.position, wallBehindCheck.position + (Vector3)(Vector2.right * facingDir * enemyData.wallCheckDist));
        Gizmos.DrawLine(ledgeBehindCheck.position, ledgeBehindCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDist));
    }
}
