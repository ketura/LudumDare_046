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

public class ModularSpriteDisplay : MonoBehaviour
{
	public Image Renderer;

	public List<NamedSprite> Sprites;

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
		if(LastTier != DisplayTier)
		{
			UpdateSprite();
		}
	}

	public void UpdateSprite()
	{
		Renderer.sprite = Sprites.Where(x => x.Tier == DisplayTier).First().Sprite;
		LastTier = DisplayTier;
	}
}
