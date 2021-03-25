using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected Enemy enemy;

    protected float startTime;

    protected string animatiorNameBool;

    protected bool isDead = false;

    public State(FiniteStateMachine stateMachine, Enemy enemy, string animatorNameBool)
    {
        this.stateMachine = stateMachine;
        this.enemy = enemy;
        this.animatiorNameBool = animatorNameBool;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        enemy.anim.SetBool(animatiorNameBool, true);
        DoChecks();
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void Exit()
    {
        enemy.anim.SetBool(animatiorNameBool, false);
    }

    public virtual void DoChecks()
    {
        isDead = enemy.CheckPlayerRunOutOfLives();
    }
}
