using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoyStateMachine : MonoBehaviour
{
	[Header("Boy ")]
	public Transform boyTransform;

	[Header("Pathing")]
	public float pathSpeed;
	public Transform pointA;
	public Transform pointB;

	[Header("Move Water")]
	public Transform waterTransformRight;
	public Transform waterTransformLeft;
	public float waterMoveSpeed;
	public float drinkWaterTime = 2f;

	private BoyBaseState _currentState;
	private bool isDrinkingWater = false;
	private Transform currentWaterTarget;

	private void Start()
	{
		_currentState = new BoyPatrolState();
		_currentState.EnterState(this);
		StartCoroutine(WaterRoutine());
	}

	private void Update()
	{
		_currentState.UpdateState(this);
	}

	public void ChangeState(BoyBaseState newState)
	{
		_currentState.ExitState(this);
		_currentState = newState;
		_currentState.EnterState(this);
	}

	private IEnumerator WaterRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(10f,15f));

			if (!isDrinkingWater)
			{
				isDrinkingWater = true;
				ChangeState(new BoyMoveState());
			}
		}
	}

	public void StartPatrolling()
	{
		isDrinkingWater = false;
		ChangeState(new BoyPatrolState());
	}
}