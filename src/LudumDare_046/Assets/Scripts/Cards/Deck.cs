using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

	public List<Card> Cards;

	private System.Random rng;

	// Start is called before the first frame update
	void Start()
	{
		rng = new System.Random(unchecked(Time.frameCount * 31 ));
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

	public void InsertCards(IEnumerable<Card> newcards)
	{
		Cards.InsertRange(0, newcards);
	}
}
