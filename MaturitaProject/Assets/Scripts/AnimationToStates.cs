using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStates : MonoBehaviour
{
    public AttackState attackState;

    private void StartAttack()
    {
        attackState.StartAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
