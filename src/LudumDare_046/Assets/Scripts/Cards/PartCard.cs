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



public class PartCard : MonoBehaviour
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
