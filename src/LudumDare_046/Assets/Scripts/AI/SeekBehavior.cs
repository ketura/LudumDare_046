using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeekBehavior : WanderBehavior
{
	public string TargetTag;

	public Creature TargetCreature;

	// Start is called before the first frame update
	protected override void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	protected void GetNewTarget(Creature creature)
	{
		var hits = Map.GetCreaturesInRadius(creature.transform.position, creature.DetectionRadius, TargetTag);


		if (hits.Count() == 0)
		{
			TargetCreature = null;
			
			return;
		}

		foreach (var hit in hits)
		{
			if (TargetCreature == null)
			{
				TargetCreature = hit;
			}
			else if (Vector3.Distance(creature.transform.position, hit.transform.position) < Vector3.Distance(creature.transform.position, TargetCreature.transform.position))
			{
				TargetCreature = hit;
			}
		}
	}

	public override void Behave(Creature creature)
	{
		
		if(TargetCreature == null)
		{
			GetNewTarget(creature);
		}
		else
		{
			CurrentTarget = TargetCreature.transform.position;
		}
		Wander(creature);

		if (TargetCreature != null)
		{
			creature.AttackBehavior.AttemptToAttack(creature, TargetCreature);
		}
	}

	protected override void Arrive(Creature creature)
	{
		if(TargetCreature == null)
		{
			base.Arrive(creature);
		}
		else
		{
			creature.AttackBehavior.AttemptToAttack(creature, TargetCreature);
			if (TargetCreature.IsDead)
				TargetCreature = null;
		}
	}
}
