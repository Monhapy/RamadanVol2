using DG.Tweening;
using UnityEngine;

public class BoyPatrolState : BoyBaseState
{
	private bool movingToB;

	public override void EnterState(BoyStateMachine stateMachine)
	{
		MoveToTarget(stateMachine);
	}

	private void MoveToTarget(BoyStateMachine stateMachine)
	{
		Transform target = movingToB ? stateMachine.pointB : stateMachine.pointA;

		stateMachine.boyTransform.DOMove(target.position, Vector3.Distance(stateMachine.boyTransform.position, target.position) / stateMachine.pathSpeed)
			.SetEase(Ease.Linear)
			.OnComplete(() =>
			{
				movingToB = !movingToB;
				MoveToTarget(stateMachine);
			});
	}

	public override void UpdateState(BoyStateMachine stateMachine) { }

	public override void ExitState(BoyStateMachine stateMachine) { }
}