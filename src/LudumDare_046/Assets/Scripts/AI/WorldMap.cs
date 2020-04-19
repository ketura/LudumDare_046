using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

public class WorldMap : Singleton<WorldMap>
{
	public Vector2 XLimits;
	public Vector2 YLimits;

	public Creature Anita;

	public List<Creature> Creatures;

	public bool IsPaused;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (IsPaused)
			return;


		foreach(var creature in Creatures)
		{
			if (creature == null)
				continue;

			creature.MoveBehavior.Behave(creature);
		}

		Anita.MoveBehavior.Behave(Anita);
	}

	public void CreateCreature()
	{

	}

	public Vector3 GetRandomPoint()
	{
		float randx = Random.Range(XLimits.x, XLimits.y);
		float randy = Random.Range(YLimits.x, YLimits.y);

		return new Vector3(randx, randy, 0);
	}

	public IEnumerable<Creature> GetCreaturesInRadius(Vector3 position, float radius, string tag)
	{
		Creatures = Creatures.Where(x => x != null).ToList();

		if(tag == "Anita")
		{
			if (Vector3.Distance(Anita.transform.position, position) <= radius)
				return new Creature[] { Anita };
			else
				return new Creature[0];
		}
		return Creatures.Where(x => Vector3.Distance(x.transform.position, position) <= radius && x.CompareTag(tag));
	}

	public void RemoveCreature(Creature creature)
	{
		Creatures.Remove(creature);
	}

	public void AddCreature(Creature creature)
	{
		Creatures.Add(creature);
	}
}
