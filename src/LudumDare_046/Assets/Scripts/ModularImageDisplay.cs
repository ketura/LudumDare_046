using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct NamedSprite
{
	public GeneTier Tier;
	public Sprite Sprite;
}

public class ModularImageDisplay : MonoBehaviour
{
	public BodyPart PartType;
	public Image ImageRenderer;
	public SpriteRenderer SpriteRenderer;

	public List<NamedSprite> Sprites;

	public GeneTier DisplayTier;

	// Start is called before the first frame update
	void Start()
	{
		DisplayTier = GeneTier.Ultimate;
	}

	public void UpdateSprite(GeneTier tier)
	{
		if (DisplayTier == tier)
			return;

		ImageRenderer.sprite = Sprites.Where(x => x.Tier == tier).First().Sprite;
		SpriteRenderer.sprite = Sprites.Where(x => x.Tier == tier).First().Sprite;
		DisplayTier = tier;
	}
}
