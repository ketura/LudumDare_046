using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

public class CardCollection : Singleton<CardCollection>
{
	public List<PartCard> PartCards;
	public List<GeneCard> GeneCards;
	public BlessingCard BlessingCard;

	// Start is called before the first frame update
	void Awake()
	{
		PartCards = GetComponents<PartCard>().ToList();
		GeneCards = GetComponents<GeneCard>().ToList();
		BlessingCard = GetComponent<BlessingCard>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public PartCard GetPartCard(BodyPart part)
	{
		return PartCards.Where(x => x.PartType == part).First();
	}

	public Card GetCard(CardType type, GeneTier tier, BodyPart part = BodyPart.None)
	{
		switch (type)
		{
			
			case CardType.Gene:
				return GeneCards.Where(x => x.Tier == tier).First();

			case CardType.Part:
				return PartCards.Where(x => x.Tier == tier && x.PartType == part).First();


			case CardType.Blessing:
			case CardType.None:
			default:
				return BlessingCard;
		}
	}
}
