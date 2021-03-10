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

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_DetectPlayerState detectPlayerStateData;
    [SerializeField]
    private D_RunState runStateData;

    public override void Start()
    {
        base.Start();

        moveState = new E2_MoveState(stateMachineEnemy, this, "move", moveStateData, this);
        idleState = new E2_IdleState(stateMachineEnemy, this, "idle", idleStateData, this);
        detectPlayerState = new E2_DetectPlayerState(stateMachineEnemy, this, "detectPlayer", detectPlayerStateData, this);
        runState = new E2_RunState(stateMachineEnemy, this, "run", runStateData, this);
        deadState = new E2_DeadState(stateMachineEnemy, this, "dead", this);

        stateMachineEnemy.Initialize(moveState);
    }

    public override void Update()
    {
        base.Update();
    }
}
