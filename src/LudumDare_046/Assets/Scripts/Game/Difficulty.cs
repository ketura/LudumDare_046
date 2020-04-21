using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Difficulty : Singleton<Difficulty>
{

	public float CurrentDifficulty;
	public float DifficultyIncrement;

	public float SpawnTier2;
	public float SpawnTier3;
	public float SpawnTier4;

	public Spawner Tier1;
	public Spawner Tier2;
	public Spawner Tier3;
	public Spawner Tier4;
	public Spawner UltimateTier;

	// Start is called before the first frame update
	void Start()
	{
		Tier1.Spawn = true;
		Tier2.Spawn = false;
		Tier3.Spawn = false;
		Tier4.Spawn = false;
		UltimateTier.Spawn = false;
	}

	// Update is called once per frame
	void Update()
	{
		
	}


	public void IncreaseDifficulty()
	{
		CurrentDifficulty += DifficultyIncrement;

		Evaluate();

	}

	public void Evaluate()
	{
		if (CurrentDifficulty >= SpawnTier4)
		{
			Tier4.Spawn = true;
		}
		if (CurrentDifficulty >= SpawnTier3)
		{
			Tier3.Spawn = true;
		}
		else if (CurrentDifficulty >= SpawnTier2)
		{
			Tier2.Spawn = true;
		}
	}

	public void KillEnemy()
	{
		CurrentDifficulty += DifficultyIncrement / 3;

		Evaluate();
	}
}
