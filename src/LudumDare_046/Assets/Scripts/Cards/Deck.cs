using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

	public List<Card> Cards;

	private System.Random rng;

	// Start is called before the first frame update
	void Awake()
	{
		rng = new System.Random((int)unchecked(System.DateTime.Now.Ticks * 31 ));
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void Shuffle()
	{
		int n = Cards.Count;
		while (n > 1)
		{
			n--;
			int k = rng.Next(n + 1);
			Card value = Cards[k];
			Cards[k] = Cards[n];
			Cards[n] = value;
		}
	}

	public Card Draw()
	{
		if (Cards.Count == 0)
			return null;

		var card = Cards[0];
		Cards.RemoveAt(0);
		return card;
	}

	public void AddCardsToBottom(IEnumerable<Card> newcards)
	{
		Cards.InsertRange(Cards.Count, newcards);
	}

	public void AddCardToBottom(Card newcard)
	{
		Cards.Insert(Cards.Count, newcard);
	}

	public void EmptyDeck()
	{
		Cards.Clear();
	}
}
