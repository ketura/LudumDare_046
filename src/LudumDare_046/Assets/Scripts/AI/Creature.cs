using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DropEntry
{
	public float Chance;
	public CardType CardType;
	public GeneTier GeneTier;
	public int MinCount;
	public int MaxCount;
}

public class Creature : MonoBehaviour
{
	public string Name;

	public int Health = 10;

	public bool IsDead => Health <= 0;

	public float DetectionRadius = 10;

	public MoveBehavior MoveBehavior;
	public AttackBehavior AttackBehavior;

	public List<DropEntry> DropTable;

	private CombatLog CombatLog;

	// Start is called before the first frame update
	void Start()
	{
		CombatLog = CombatLog.Instance;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public virtual void Damage(int amount)
	{
		Health -= amount;
		if(IsDead)
		{
			Die();
		}
	}

	public virtual void Die()
	{
		WorldMap.Instance.RemoveCreature(this);
		CombatLog.LogItem($"{Name} has died!");

		if (this.tag == "Anita")
		{
			EndConditions.Instance.PlayerLose();
		}
		else
		{
			
			CardHandler.Instance.InsertLoot(Camera.main.WorldToScreenPoint(transform.position), RollLoot());
			Destroy(gameObject);
		}
		
	}

	public virtual IEnumerable<Card> RollLoot()
	{
		List<Card> loot = new List<Card>();

		var definitionLookup = CardCollection.Instance;

		

		foreach (var item in DropTable)
		{
			if (item.CardType == CardType.None || Random.value > item.Chance)
				continue;

			BodyPart part = BodyPart.None;

			if (item.CardType == CardType.Part)
			{
				part = (BodyPart)Random.Range((int)BodyPart.Mandibles, (int)BodyPart.Wings);
			}
			var card = definitionLookup.GetCard(item.CardType, item.GeneTier, part);

			int amount = Random.Range(item.MinCount, item.MaxCount + 1);
			for(int i = 0; i < amount; i++)
			{
				loot.Add(card);
			}
		}

		return loot;
	}
}
