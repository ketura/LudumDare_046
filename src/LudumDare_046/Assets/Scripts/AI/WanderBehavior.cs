
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : MoveBehavior
{
	public static Vector3 NullTarget = new Vector3(-1000, -1000, -1000);
	public Vector3 CurrentTarget;

	public float Speed = 1.0f;
	public float RotationSpeed = 1.0f;


	// Start is called before the first frame update
	protected override void Start()
	{
		CurrentTarget = NullTarget;
		base.Start();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public override void Behave(Creature creature)
	{
		if (creature == null)
			return;

		Wander(creature);
	}

	protected void GetRandomTarget(Creature creature)
	{
		CurrentTarget = Map.GetRandomPoint();
	}

	protected void Wander(Creature creature)
	{
		if (creature == null)
			return;

		if(CurrentTarget == NullTarget)
		{
			GetRandomTarget(creature);
		}
		

		//creature.transform.Rotate(new Vector3(0, 10 * Time.deltaTime, 0));


		//Quaternion targetRotation = Quaternion.LookRotation(CurrentTarget - transform.position);

		//transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
		var delta = (CurrentTarget - creature.transform.position);
		delta.Normalize();

		if(Vector3.Distance(CurrentTarget, creature.transform.position) > 0.1f)
		{
			creature.transform.up = delta;
		}
		
		//transform.rotation = Quaternion.LookRotation(delta, Vector3.forward);
		var target = creature.transform.position + (delta * Time.deltaTime * Speed);
		//Debug.Log(target);
		//float x = target.x;
		//float y = target.y;

		//x = Mathf.Clamp(x, Map.XLimits.x, Map.XLimits.y);
		//y = Mathf.Clamp(y, Map.YLimits.x, Map.YLimits.y);
		//Debug.Log(target);
		//target = new Vector3(x, y, 0);
		creature.transform.position = target;
		//rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity + (targetRotation * new Vector3(0, 0, Acceleration * Time.deltaTime)), MaxSpeed);

		if(Vector2.Distance(target, CurrentTarget) < 1.0f)
		{
			Arrive(creature);
		}
	}

	protected virtual void Arrive(Creature creature)
	{
		CurrentTarget = NullTarget;
		GetRandomTarget(creature);
	}
}
