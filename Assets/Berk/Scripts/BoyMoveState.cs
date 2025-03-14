using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BoyMoveState : BoyBaseState
{
    public override void EnterState(BoyStateMachine stateMachine)
    {
        Transform targetWater = stateMachine.transform.position.x > 0 ? stateMachine.waterTransformRight : stateMachine.waterTransformLeft;

        stateMachine.boyTransform.DOMove(targetWater.position, stateMachine.waterMoveSpeed)
            .SetEase(Ease.Linear)
            .OnComplete(() => stateMachine.StartCoroutine(DrinkWater(stateMachine)));
    }

    private IEnumerator DrinkWater(BoyStateMachine stateMachine)
    {
        yield return new WaitForSeconds(stateMachine.drinkWaterTime);
        stateMachine.StartPatrolling();
    }

    public override void UpdateState(BoyStateMachine stateMachine) { }

    public override void ExitState(BoyStateMachine stateMachine) { }
}