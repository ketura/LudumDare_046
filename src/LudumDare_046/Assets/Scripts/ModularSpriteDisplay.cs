using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ModularSpriteDisplay : MonoBehaviour
{
	public BodyPart PartType;
	public SpriteRenderer Renderer;

	public List<NamedSprite> Sprites;

	public GeneTier DisplayTier;

	private GeneTier LastTier;
	// Start is called before the first frame update
	void Start()
	{
		DisplayTier = GeneTier.One;
		LastTier = GeneTier.Ultimate;
	}

	public void UpdateSprite(GeneTier tier)
	{
		if (LastTier == tier)
			return;

		Renderer.sprite = Sprites.Where(x => x.Tier == DisplayTier).First().Sprite;
		LastTier = DisplayTier;
	}

}
