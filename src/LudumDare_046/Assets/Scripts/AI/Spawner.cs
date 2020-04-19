using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour
{
	public List<GameObject> SpawnTable;

	public WorldMap Map;

	public float SecondsPerSpawn = 1;

	private bool CanSpawn;

	public bool Spawn = true;

	private void Start()
	{
		CanSpawn = true;
		StartCoroutine(SpawnLoop());
	}

	public void SpawnCreature(GameObject CreaturePrefab)
	{
		Vector3 randPoint = Map.GetRandomPoint();
		float x = randPoint.x;
		float y = randPoint.y;

		if(x < -15)
		{
			x = Map.XLimits.x;
		}
		else if(x > 15)
		{
			x = Map.XLimits.y;
		}
		else if(y >= 0)
		{
			y = Map.YLimits.y;
		}
		else
		{
			y = Map.YLimits.x;
		}

		var creature = Instantiate(CreaturePrefab, new Vector3(x, y, 0), Quaternion.identity).GetComponent<Creature>();

		Map.AddCreature(creature);

	}

	IEnumerator SpawnLoop()
	{
		while (Spawn)
		{
			CanSpawn = false;
			yield return new WaitForSeconds(SecondsPerSpawn);

			if (WorldMap.Instance.IsPaused || !Spawn)
				continue;

			Debug.Log("Spawning...");
			int index = Random.Range(0, SpawnTable.Count - 1);
			SpawnCreature(SpawnTable[index]);
			CanSpawn = true;
		}
	}
}
