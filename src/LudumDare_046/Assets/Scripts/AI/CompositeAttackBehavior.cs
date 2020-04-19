using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeAttackBehavior : AttackBehavior
{
	public List<AttackBehavior> Behaviors;

	public override bool CanAttack { get => true; protected set => base.CanAttack = value; }

	public override void AttemptToAttack(Creature source, Creature target)
	{
		foreach(var attack in Behaviors)
		{
			if(attack.CanAttack)
			{
				attack.AttemptToAttack(source, target);
				EngageCooldown();
				break;
			}
		}
	}
}
