﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDecetingLedge;

    public MoveState(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool, D_MoveState stateData) : base(stateMachine, enemy, animatorNameBool)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.SetVelocity(stateData.movementSpeed);

        isDecetingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();

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

        isDecetingLedge = enemy.CheckLedge();
        isDetectingWall = enemy.CheckWall();
    }
}