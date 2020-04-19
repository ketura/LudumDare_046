using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : AIBehavior
{
	public string Name;

	public int Damage = 1;

	public float AttackRange = 1.0f;

	public float Windup = 0.5f;
	public float Cooldown = 2.0f;


	public virtual bool CanAttack { get; protected set; }
	public virtual bool IsAttacking { get; protected set; }


	protected override void Start()
	{
		base.Start();
		CanAttack = true;
	}

	public virtual void AttemptToAttack(Creature source, Creature target)
	{
		if (!CanAttack)
			return;

		if (IsAttacking)
			return;

		if (Vector3.Distance(source.transform.position, target.transform.position) <= AttackRange)
		{
			Debug.Log($"{source.Name} winding up to attack {target.Name} with {this.Name} for {this.Damage}!");
			StartAttack(source,target);
		}

	}

	public virtual void StartAttack(Creature source, Creature target)
	{
		StartCoroutine(AttackWindup(source, target));
	}

	IEnumerator AttackWindup(Creature source, Creature target)
	{
		IsAttacking = true;
		yield return new WaitForSeconds(Windup);
		IsAttacking = false;

		if (Vector3.Distance(source.transform.position, target.transform.position) <= AttackRange)
		{
			Debug.Log($"{source.Name} attacking {target.Name} with {this.Name} for {this.Damage}!");
			target.Damage(Damage);
			EngageCooldown();
		}
	}

	public virtual void EngageCooldown()
	{
		StartCoroutine(WaitForCooldown());
	}

	IEnumerator WaitForCooldown()
	{
		CanAttack = false;
		yield return new WaitForSeconds(Cooldown);
		CanAttack = true;
	}
}
