using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPart
{
	None,
	Mandibles,
	Antennae,
	Head,
	Thorax,
	Abdomen,
	Legs,
	Wings
}



public class PartCard : Card
{
	public BodyPart PartType;

	public GeneTier Tier;

	public int MaxHealth;
	public int CurrentHealth;

	// Mandibles: Damage
	// Antennae: Range
	// Legs: Speed
	// Abdomen: Damage
	// Thorax: Damage Reflection Percentage
	public float Modifier1;

	// Mandibles: Range
	// Antennae: Additional Damage
	// Legs: Evasion
	// Abdomen: Range
	// Thorax: Speed Percentage Modifier
	public float Modifier2;

	// Mandibles: Wind-up
	// Antennae: Additional Drops
	// Legs: Damage Bonus
	// Abdomen: Wind-up
	// Thorax: Evasion
	public float Modifier3;

	// Mandibles: Cooldown
	// Antennae: Evasion
	// Abdomen: Cooldown
	public float Modifier4;


	public float HealthPercentage => Mathf.Max(CurrentHealth, MaxHealth / 2.0f) / (MaxHealth * 1.0f);

	public float AdjustedModifier1 => Modifier1 * HealthPercentage;
	public float AdjustedModifier2 => Modifier2 * HealthPercentage;
	public float AdjustedModifier3 => Modifier3 * HealthPercentage;
	public float AdjustedModifier4 => Modifier4 * HealthPercentage;

	public float InvertedModifier1 => HealthPercentage <= 0.1f ? 5.0f : Modifier1 * Mathf.Min(1 / HealthPercentage, 5.0f);
	public float InvertedModifier2 => HealthPercentage <= 0.1f ? 5.0f : Modifier2 * Mathf.Min(1 / HealthPercentage, 5.0f);
	public float InvertedModifier3 => HealthPercentage <= 0.1f ? 5.0f : Modifier3 * Mathf.Min(1 / HealthPercentage, 5.0f);
	public float InvertedModifier4 => HealthPercentage <= 0.1f ? 5.0f : Modifier4 * Mathf.Min(1 / HealthPercentage, 5.0f);


	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}


	public int PerformDamage(int damage)
	{
		if(CurrentHealth >= damage)
		{
			CurrentHealth -= damage;
			return 0;
		}

		int remainder = CurrentHealth;
		CurrentHealth = 0;
		return damage - remainder;
	}
}
