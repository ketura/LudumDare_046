using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnitaStatConsolidator : MonoBehaviour
{

	public AnitaCreature Anita;

	public CompositeImageDisplay SpriteDisplay;


	public PartCard Head;
	public PartCard Mandibles;
	public PartCard Antennae;
	public PartCard Thorax;
	public PartCard Legs;
	public PartCard Abdomen;

	public Slider HeadSlider;
	public Slider MandibleSlider;
	public Slider AntennaeSlider;
	public Slider ThoraxSlider;
	public Slider LegSlider;
	public Slider AbdomenSlider;

	public TMP_Text HeadTierLabel;
	public TMP_Text MandibleTierLabel;
	public TMP_Text AntennaeTierLabel;
	public TMP_Text ThoraxTierLabel;
	public TMP_Text LegTierLabel;
	public TMP_Text AbdomenTierLabel;

	// Start is called before the first frame update
	void Start()
	{
		Head = new PartCard();
		Mandibles = new PartCard();
		Antennae = new PartCard();
		Legs = new PartCard();
		Thorax = new PartCard();
		Abdomen = new PartCard();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public int GetMaxHealth()
	{
		return Head.MaxHealth + Mandibles.MaxHealth + Antennae.MaxHealth + Thorax.MaxHealth + Legs.MaxHealth + Abdomen.MaxHealth;
	}

	public int GetCurrentHealth()
	{
		return Head.CurrentHealth + Mandibles.CurrentHealth + Antennae.CurrentHealth + Thorax.CurrentHealth + Legs.CurrentHealth + Abdomen.CurrentHealth;
	}

	private void UpdateTierLabel(TMP_Text textbox, GeneTier tier)
	{
		string text = "";
		switch (tier)
		{
			case GeneTier.One:
				text = "Basic Tier";
				break;
			case GeneTier.Two:
				text = "Advanced Tier";
				break;
			case GeneTier.Alpha:
				text = "Alpha Tier";
				break;
			case GeneTier.Beta:
				text = "Beta Tier";
				break;
			case GeneTier.Gamma:
				text = "Gamma Tier";
				break;
			case GeneTier.Ultimate:
				text = "Ultimate Tier";
				break;
			default:
				break;
		}

		textbox.text = text;
	}

	public void UpdateStats()
	{
		Anita.Health = GetCurrentHealth();

		HeadSlider.maxValue = Head.MaxHealth;
		HeadSlider.value = Head.CurrentHealth;
		MandibleSlider.maxValue = Mandibles.MaxHealth;
		MandibleSlider.value = Mandibles.CurrentHealth;
		AntennaeSlider.maxValue = Antennae.MaxHealth;
		AntennaeSlider.value = Antennae.CurrentHealth;
		ThoraxSlider.maxValue = Thorax.MaxHealth;
		ThoraxSlider.value = Thorax.CurrentHealth;
		LegSlider.maxValue = Legs.MaxHealth;
		LegSlider.value = Legs.CurrentHealth;
		AbdomenSlider.maxValue = Abdomen.MaxHealth;
		AbdomenSlider.value = Abdomen.CurrentHealth;

		UpdateTierLabel(HeadTierLabel, Head.Tier);
		UpdateTierLabel(MandibleTierLabel, Mandibles.Tier);
		UpdateTierLabel(AntennaeTierLabel, Antennae.Tier);
		UpdateTierLabel(ThoraxTierLabel, Thorax.Tier);
		UpdateTierLabel(LegTierLabel, Legs.Tier);
		UpdateTierLabel(AbdomenTierLabel, Abdomen.Tier);

		SpriteDisplay.UpdateTier(BodyPart.Head, Head.Tier);
		SpriteDisplay.UpdateTier(BodyPart.Mandibles, Mandibles.Tier);
		SpriteDisplay.UpdateTier(BodyPart.Antennae, Antennae.Tier);
		SpriteDisplay.UpdateTier(BodyPart.Thorax, Thorax.Tier);
		SpriteDisplay.UpdateTier(BodyPart.Legs, Legs.Tier);
		SpriteDisplay.UpdateTier(BodyPart.Abdomen, Abdomen.Tier);

		Anita.BiteDamage = Mathf.CeilToInt(Mandibles.Modifier1 + (Mandibles.Modifier1 * (Legs.Modifier3 + Antennae.Modifier2)));
		Anita.BiteAttackRange = Mandibles.Modifier2;
		Anita.BiteWindup = Mandibles.Modifier3;
		Anita.BiteCooldown = Mandibles.Modifier4;

		Anita.DetectionRadius = Antennae.Modifier1;
		Anita.DropBonus = Mathf.FloorToInt(Antennae.Modifier3);
		Anita.EvasionChance = Antennae.Modifier4 + Legs.Modifier2 + Thorax.Modifier3;

		Anita.StingDamage = Mathf.CeilToInt(Abdomen.Modifier1 + (Mandibles.Modifier1 * (Legs.Modifier3 + Antennae.Modifier2)));
		Anita.StingAttackRange = Abdomen.Modifier2;
		Anita.StingWindup = Abdomen.Modifier3;
		Anita.StingCooldown = Abdomen.Modifier4;

		Anita.MovementSpeed = Legs.Modifier1 * Thorax.Modifier2;

		Anita.DamageReflection = Thorax.Modifier1;
	}

	public void TakeDamage(int damage)
	{
		float hitAttempt = Random.Range(0, 1.0f);
		if (hitAttempt <= Anita.EvasionChance)
		{
			//whiff sound effect
			damage = 0;
		}

		hitAttempt = Random.Range(0, 1.0f);
		if (hitAttempt <= Anita.BlockChance)
		{
			//clink sound effect

			damage = (int)(damage * Anita.BlockPercent);
		}


		while (damage > 0)
		{
			switch (Random.Range(0, 6))
			{
				case 0:
					damage = Head.PerformDamage(damage);
					break;
				case 1:
					damage = Mandibles.PerformDamage(damage);
					break;
				case 2:
					damage = Antennae.PerformDamage(damage);
					break;
				case 3:
					damage = Thorax.PerformDamage(damage);
					break;
				case 4:
					damage = Legs.PerformDamage(damage);
					break;
				case 5:
					damage = Abdomen.PerformDamage(damage);
					break;
			}

			if (GetCurrentHealth() <= 0)
				break;
		}

		UpdateStats();
	}

	public PartCard SwapPart(BodyPart slot, PartCard newPart)
	{
		PartCard retval = null;
		switch (slot)
		{

			case BodyPart.Mandibles:
				retval = Mandibles;
				Mandibles = newPart;
				break;

			case BodyPart.Antennae:
				retval = Antennae;
				Antennae = newPart;
				break;

			case BodyPart.Head:
				retval = Head;
				Head = newPart;
				break;

			case BodyPart.Thorax:
				retval = Thorax;
				Thorax = newPart;
				break;

			case BodyPart.Abdomen:
				retval = Abdomen;
				Abdomen = newPart;
				break;

			case BodyPart.Legs:
				retval = Legs;
				Legs = newPart;
				break;

			default:
				throw new System.Exception("wtf");

		}

		UpdateStats();
		return retval;
	}
	
}
