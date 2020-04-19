using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DropEntry
{
	public float Chance;
	public object Reward;
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

	// Start is called before the first frame update
	void Start()
	{
		
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
		if(this.tag == "Anita")
		{
			EndConditions.Instance.PlayerLose();
		}
		else
		{
			Destroy(gameObject);
		}
		
	}
}
