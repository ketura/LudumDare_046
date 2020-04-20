using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGroup : MonoBehaviour
{
	public Card Slot1;
	public Card Slot2;
	public Card Slot3;
	public Card Slot4;
	public Card Slot5;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public bool IsEmpty()
	{
		return GetAllActiveCards().Count() == 0;
	}

	public void RemoveAllCards()
	{
		Slot1 = null;
		Slot2 = null;
		Slot3 = null;
		Slot4 = null;
		Slot5 = null;
	}

	public IEnumerable<Card> GetAllActiveCards()
	{
		var cards = new List<Card>();
		if (Slot1 != null)
		{
			cards.Add(Slot1);
		}
		if (Slot2 != null)
		{
			cards.Add(Slot2);
		}
		if (Slot3 != null)
		{
			cards.Add(Slot3);
		}
		if (Slot4 != null)
		{
			cards.Add(Slot4);
		}
		if (Slot5 != null)
		{
			cards.Add(Slot5);
		}

		return cards;
	}

	public bool InsertCardAtSlot(int slot, Card card)
	{
		switch (slot)
		{
			case 1:
				if (Slot1 == null)
				{
					Slot1 = card;
					return true;
				}
				return false;

			case 2:
				if (Slot2 == null)
				{
					Slot2 = card;
					return true;
				}
				return false;

			case 3:
				if (Slot3 == null)
				{
					Slot3 = card;
					return true;
				}
				return false;

			case 4:
				if (Slot4 == null)
				{
					Slot4 = card;
					return true;
				}
				return false;

			case 5:
				if (Slot5 == null)
				{
					Slot5 = card;
					return true;
				}
				return false;

			default:
				return false;
		}
	}

	public Card RemoveCardAtSlot(int slot)
	{
		Card card = null;
		switch (slot)
		{
			case 1:
				card = Slot1;
				Slot1 = null;
				break;

			case 2:
				card = Slot2;
				Slot2 = null;
				break;

			case 3:
				card = Slot3;
				Slot3 = null;
				break;

			case 4:
				card = Slot4;
				Slot4 = null;
				break;

			case 5:
				card = Slot5;
				Slot5 = null;
				break;

			default:
				card = null;
				break;
		}

		return card;
	}


	public Card GetCardAtSlot(int slot)
	{
		switch (slot)
		{
			case 1:
				return Slot1;

			case 2:
				return Slot2;

			case 3:
				return Slot3;

			case 4:
				return Slot4;

			case 5:
				return Slot5;
		}

		return null;
	}
}
