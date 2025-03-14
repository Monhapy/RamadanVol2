using System.Collections;
using UnityEngine;

public class AIChase : MonoBehaviour
{
	public Transform patrolPoint1;
	public Transform patrolPoint2;
	public Transform waitPoint;
	public Transform secondaryPoint;
	public float patrolDuration = 5f;
	public float moveSpeed = 2f;
    
	private bool isPatrolling = true;
	private bool isWaiting = false;
	private Transform currentTarget;
	private float patrolTimer;
	public AudioSource audioSource;
	
	public Animator animator;
	void Start()
	{
		currentTarget = patrolPoint1;
		patrolTimer = patrolDuration;
	}

	void Update()
	{
		if (isPatrolling)
		{
			Patrol();
		}
		else if (isWaiting)
		{
			// AI waiting at secondary point, does nothing unless clicked
		}
	}

	void Patrol()
	{
		transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        
		if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
		{
			currentTarget = currentTarget == patrolPoint1 ? patrolPoint2 : patrolPoint1;
		}
        
		patrolTimer -= Time.deltaTime;
		if (patrolTimer <= 0)
		{
			StartCoroutine(GoToWaitPoint());
		}
	}

	IEnumerator GoToWaitPoint()
	{
		isPatrolling = false;
		currentTarget = waitPoint;
		yield return MoveToTarget(waitPoint);
		yield return MoveToTarget(secondaryPoint);
		isWaiting = true;
	}

	IEnumerator MoveToTarget(Transform target)
	{
		while (Vector2.Distance(transform.position, target.position) > 0.1f)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
			yield return null;
		}
	}

	void OnMouseDown()
	{
		if (isWaiting)
		{
			isWaiting = false;
			isPatrolling = true;
			currentTarget = patrolPoint1;
			patrolTimer = patrolDuration;
			animator.SetTrigger("Smash");
			audioSource.Play();
		}
	}
}
