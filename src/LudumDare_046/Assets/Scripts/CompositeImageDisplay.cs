﻿using System.Collections;
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

public class CompositeImageDisplay : MonoBehaviour
{
	public List<ModularImageDisplay> ImageParts;

	public GeneTier DisplayTier;

	private GeneTier LastTier;

	// Start is called before the first frame update
	void Start()
	{
		DisplayTier = GeneTier.One;
		LastTier = GeneTier.Ultimate;

		UpdateAllSprites();
	}

	private void Update()
	{
		if (LastTier != DisplayTier)
			UpdateAllSprites();
	}



	public void UpdateAllSprites()
	{
		foreach (var part in ImageParts)
		{
			part.UpdateSprite(DisplayTier);
		}

		LastTier = DisplayTier;
	}

	public void UpdateTier(BodyPart part, GeneTier tier)
	{
		foreach (var image in ImageParts)
		{
			if (image.PartType == part)
			{
				image.UpdateSprite(tier);
				break;
			}

		}
	}
}
