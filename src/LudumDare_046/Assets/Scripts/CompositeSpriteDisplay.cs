using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeSpriteDisplay : MonoBehaviour
{
	public List<ModularSpriteDisplay> Parts;

	public GeneTier DisplayTier;

	private GeneTier LastTier;

	// Start is called before the first frame update
	void Start()
	{
		DisplayTier = GeneTier.One;
		LastTier = GeneTier.Ultimate;
	}

	// Update is called once per frame
	void Update()
	{
		if (LastTier != DisplayTier)
		{
			UpdateSprite();
		}
	}

	public void UpdateSprite()
	{
		foreach(var part in Parts)
		{
			part.DisplayTier = DisplayTier;
		}
		LastTier = DisplayTier;
	}
}
