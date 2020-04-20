using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnitaStatConsolidator))]
public class AnitaCreature : Creature
{
	public AnitaStatConsolidator StatConsolidator;

	public int BiteDamage = 1;
	public float BiteAttackRange = 1.0f;
	public float BiteWindup = 0.5f;
	public float BiteCooldown = 2.0f;

	public int StingDamage = 1;
	public float StingAttackRange = 1.0f;
	public float StingWindup = 0.5f;
	public float StingCooldown = 2.0f;

	public float MovementSpeed = 1.0f;

	public float EvasionChance = 0.0f;
	public float BlockChance = 0.0f;
	public float BlockPercent = 0.0f;

	public float DamageReflection = 0.0f;

	public int DropBonus = 0;


	// Start is called before the first frame update
	void Start()
	{
		StatConsolidator = GetComponent<AnitaStatConsolidator>();
		StartCoroutine(DelayedStart());
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	IEnumerator DelayedStart()
	{
		yield return new WaitForEndOfFrame();
		StatConsolidator.SpriteDisplay.UpdateAllSprites();
	}


	public override void Damage(int amount)
	{
		StatConsolidator.TakeDamage(amount);

		if(DamageReflection > 0)
		{
			var seek = MoveBehavior as SeekBehavior;

			if (seek != null)
			{
				seek.TargetCreature.Damage((int)(amount * DamageReflection));
			}
		}
		

		if (IsDead)
		{
			Die();
		}
	}

	public override void Die()
	{

		EndConditions.Instance.PlayerLose();


	}
}
