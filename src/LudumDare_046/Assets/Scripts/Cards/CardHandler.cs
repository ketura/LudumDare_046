using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{

	private EventSystem EventSystem;

	public DisplayCard HandSlot1;
	public DisplayCard HandSlot2;
	public DisplayCard HandSlot3;
	public DisplayCard HandSlot4;
	public DisplayCard HandSlot5;

	public DisplayCard EquipSlot;

	public DisplayCard CombineSlot1;
	public DisplayCard CombineSlot2;
	public DisplayCard CombineSlot3;

	public DisplayCard InfuseSlot1;
	public DisplayCard InfuseSlot2;

	public AnitaStatConsolidator AnitaStat;

	public CardCollection CardDefinitions;

	public CardGroup Hand;
	public CardGroup Equips;
	public CardGroup Infuses;
	public CardGroup Combines;

	public Deck Deck;

	public Button EquipButton;
	public Button CombineButton;
	public Button InfuseButton;

	public Deck DefaultDeck;


	public int SelectedHandSlot = 0;

	// Start is called before the first frame update
	void Start()
	{
		EventSystem = EventSystem.current;

		WipeBoardClean();

		DeselectAll();

		InsertDefaultDeck();
	}

	IEnumerator DelayedStart()
	{
		yield return new WaitForSeconds(0.1f);
		WipeBoardClean();

		DeselectAll();

		InsertDefaultDeck();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void InsertDefaultDeck()
	{
		Deck.AddCardsToBottom(DefaultDeck.Cards);
		Deck.Shuffle();
	}

	private void WipeBoardClean()
	{
		HandSlot1.HideCard();
		HandSlot2.HideCard();
		HandSlot3.HideCard();
		HandSlot4.HideCard();
		HandSlot5.HideCard();

		EquipSlot.HideCard();

		CombineSlot1.HideCard();
		CombineSlot2.HideCard();
		CombineSlot3.HideCard();

		InfuseSlot1.HideCard();
		InfuseSlot2.HideCard();

		var cards = new List<Card>();

		cards.AddRange(Hand.GetAllActiveCards());
		cards.AddRange(Equips.GetAllActiveCards());
		cards.AddRange(Combines.GetAllActiveCards());
		cards.AddRange(Infuses.GetAllActiveCards());

		Hand.RemoveAllCards();
		Equips.RemoveAllCards();
		Combines.RemoveAllCards();
		Infuses.RemoveAllCards();

		Deck.AddCardsToBottom(cards);

		DeselectAll();
	}


	#region Helpers
	private DisplayCard GetHandDisplay(int slot)
	{
		switch (slot)
		{
			case 1:
				return HandSlot1;
			case 2:
				return HandSlot2;
			case 3:
				return HandSlot3;
			case 4:
				return HandSlot4;
			case 5:
				return HandSlot5;
		}

		throw new System.ArgumentException("wierd slot number received");
	}

	private Card GetHandCard(int slot)
	{
		switch (slot)
		{
			case 1:
				return Hand.Slot1;
			case 2:
				return Hand.Slot2;
			case 3:
				return Hand.Slot3;
			case 4:
				return Hand.Slot4;
			case 5:
				return Hand.Slot5;
		}

		throw new System.ArgumentException("wierd slot number received");
	}

	private Card GetEquipCard()
	{
		return Equips.Slot1;
	}

	private DisplayCard GetCombineDisplay(int slot)
	{
		switch (slot)
		{
			case 1:
				return CombineSlot1;
			case 2:
				return CombineSlot2;
			case 3:
				return CombineSlot3;
		}

		throw new System.ArgumentException("wierd slot number received");
	}

	private Card GetCombineCard(int slot)
	{
		switch (slot)
		{
			case 1:
				return Combines.Slot1;
			case 2:
				return Combines.Slot2;
			case 3:
				return Combines.Slot3;
		}

		throw new System.ArgumentException("wierd slot number received");
	}

	private DisplayCard GetInfuseDisplay(int slot)
	{
		switch (slot)
		{
			case 1:
				return InfuseSlot1;
			case 2:
				return InfuseSlot2;
		}

		throw new System.ArgumentException("wierd slot number received");
	}

	private Card GetInfuseCard(int slot)
	{
		switch (slot)
		{
			case 1:
				return Infuses.Slot1;
			case 2:
				return Infuses.Slot2;
		}

		throw new System.ArgumentException("wierd slot number received");
	}

	#endregion


	private void RedrawAll()
	{
		HandSlot1.ShowCard(Hand.Slot1);
		HandSlot2.ShowCard(Hand.Slot2);
		HandSlot3.ShowCard(Hand.Slot3);
		HandSlot4.ShowCard(Hand.Slot4);
		HandSlot5.ShowCard(Hand.Slot5);

		EquipSlot.ShowCard(Equips.Slot1);

		CombineSlot1.ShowCard(Combines.Slot1);
		CombineSlot2.ShowCard(Combines.Slot2);
		CombineSlot3.ShowCard(Combines.Slot3);

		InfuseSlot1.ShowCard(Infuses.Slot1);
		InfuseSlot2.ShowCard(Infuses.Slot2);
	}

	private void DeselectAll()
	{
		EventSystem.SetSelectedGameObject(null);
		SelectedHandSlot = 0;

		EquipSlot.DisableSelection();
		CombineSlot1.DisableSelection();
		CombineSlot2.DisableSelection();
		CombineSlot3.DisableSelection();
		InfuseSlot1.DisableSelection();
		InfuseSlot2.DisableSelection();

		EquipButton.gameObject.SetActive(false);
		CombineButton.gameObject.SetActive(false);
		InfuseButton.gameObject.SetActive(false);
	}

	private void SelectHandCard(int slot)
	{
		SelectedHandSlot = slot;

		EquipSlot.EnableSelection();
		CombineSlot1.EnableSelection();
		CombineSlot2.EnableSelection();
		CombineSlot3.EnableSelection();
		InfuseSlot1.EnableSelection();
		InfuseSlot2.EnableSelection();
	}

	public void BackgroundClick()
	{
		Debug.Log($"Background click");
	}

	public void SelectHandSlot(int slot)
	{
		Debug.Log($"Hand Select ({slot})");

		DeselectAll();

		var card = GetHandCard(slot);

		if(card == null)
		{
			DrawCardAt(slot);
		}
		else
		{
			SelectedHandSlot = slot;
			EventSystem.SetSelectedGameObject(GetHandDisplay(slot).SelectionButton.gameObject);

			switch (card.CardType)
			{
				case CardType.None:
					break;
				case CardType.Gene:
					Debug.Log("Selecting a gene card from hand");
					if (Infuses.Slot2 == null)
					{
						InfuseSlot2.EnableSelection();
					}

					if (Combines.GetAllActiveCards().Any(x => x.CardType == CardType.Part))
						break;

					if (Combines.Slot1 == null)
					{
						CombineSlot1.EnableSelection();
					}
					if (Combines.Slot2 == null)
					{
						CombineSlot2.EnableSelection();
					}
					if (Combines.Slot3 == null)
					{
						CombineSlot3.EnableSelection();
					}

					break;

				case CardType.Part:
					if(Infuses.Slot1 == null)
					{
						InfuseSlot1.EnableSelection();
					}

					if(Equips.Slot1 == null)
					{
						EquipSlot.EnableSelection();
					}

					//if(Combines.IsEmpty() || !Combines.GetAllActiveCards().Any(x => x.CardType == CardType.Gene))
					//{
					//	var partcard = card as PartCard;
						
					//	if(partcard.Tier == GeneTier.Alpha || partcard.Tier == GeneTier.Beta || partcard.Tier == GeneTier.Gamma)
					//	{
					//		if (Combines.Slot1 == null)
					//		{
					//			CombineSlot1.EnableSelection();
					//		}
					//		if (Combines.Slot2 == null)
					//		{
					//			CombineSlot2.EnableSelection();
					//		}
					//		if (Combines.Slot3 == null)
					//		{
					//			CombineSlot3.EnableSelection();
					//		}
					//	}
					//}
					break;
				case CardType.Blessing:
					if (Equips.Slot1 != null)
					{
						EquipButton.gameObject.SetActive(true);
					}

					if (Combines.Slot1 != null && Combines.Slot2 != null && Combines.Slot3 != null)
					{
						//var combines = Combines.GetAllActiveCards().Select(x => x as PartCard);
						//if (!combines.Any(x => x.CardType == CardType.Part) || 
						//		(
						//			combines.Any(x => x.Tier == GeneTier.Alpha) && combines.Any(x => x.Tier == GeneTier.Beta) && combines.Any(x => x.Tier == GeneTier.Gamma)
						//		)
						//	)
						CombineButton.gameObject.SetActive(true);
					}

					if (Infuses.Slot1 != null && Infuses.Slot2 != null)
					{
						var oldPart = Infuses.GetCardAtSlot(1) as PartCard;
						var oldGene = Infuses.GetCardAtSlot(2) as GeneCard;

						if (oldPart.Tier < oldGene.Tier)
						{
							InfuseButton.gameObject.SetActive(true);
						}
					}
					break;
				default:
					break;
			}
		}

		//GetHandDisplay(slot).ShowCard(card);
	}

	public void DiscardHandSlot(int slot)
	{
		Debug.Log($"Hand Discard ({slot})");

		if(SelectedHandSlot == slot)
		{
			DeselectAll();
		}

		var card = Hand.RemoveCardAtSlot(slot);

		if(card != null)
		{
			Deck.AddCardToBottom(card);
		}

		RedrawAll();
	}

	public void SelectEquipSlot()
	{
		Debug.Log("Equip Select");

		var card = Hand.RemoveCardAtSlot(SelectedHandSlot);
		Equips.InsertCardAtSlot(1, card);
		DeselectAll();
		RedrawAll();
	}

	public void DiscardEquipSlot()
	{
		Debug.Log("Equip Discard");
		var card = Equips.RemoveCardAtSlot(1);

		if (card != null)
		{
			Deck.AddCardToBottom(card);
		}

		RedrawAll();
	}

	public void SelectCombineSlot(int slot)
	{
		if (SelectedHandSlot == 0 ||
			Combines.GetCardAtSlot(slot) != null)
			return;

		Debug.Log($"Combine Select ({slot})");
		
		var card = Hand.RemoveCardAtSlot(SelectedHandSlot);
		Combines.InsertCardAtSlot(slot, card);
		DeselectAll();
		RedrawAll();
	}

	public void DiscardCombineSlot(int slot)
	{
		Debug.Log($"Combine Discard ({slot})");
		var card = Combines.RemoveCardAtSlot(slot);

		if (card != null)
		{
			Deck.AddCardToBottom(card);
		}

		RedrawAll();
	}

	public void SelectInfuseSlot(int slot)
	{
		if (SelectedHandSlot == 0 ||
			Infuses.GetCardAtSlot(slot) != null)
			return;

		Debug.Log($"Infuse Select ({slot})");


		var card = Hand.RemoveCardAtSlot(SelectedHandSlot);
		Infuses.InsertCardAtSlot(slot, card);
		DeselectAll();
		RedrawAll();
	}

	public void DiscardInfuseSlot(int slot)
	{
		Debug.Log($"Infuse Discard ({slot})");

		var card = Infuses.RemoveCardAtSlot(slot);

		if (card != null)
		{
			Deck.AddCardToBottom(card);
		}

		RedrawAll();
	}

	private int GetFirstEmptySlot()
	{
		if (Hand.Slot1 == null)
			return 1;

		if (Hand.Slot2 == null)
			return 2;

		if (Hand.Slot3 == null)
			return 3;

		if (Hand.Slot4 == null)
			return 4;

		if (Hand.Slot5 == null)
			return 5;

		return 0;
	}

	public void DrawCard()
	{
		Debug.Log($"Draw Select");

		int slot = GetFirstEmptySlot();
		DrawCardAt(slot);
	}

	public void DrawCardAt(int slot)
	{
		if (slot == 0 || Hand.GetCardAtSlot(slot) != null)
			return;

		var newcard = Deck.Draw();

		if (newcard == null)
		{
			// play error tone, display empty deck
			DeselectAll();
			return;
		}


		Debug.Log($"Drawing card into {slot}");
		if (slot == 0)
		{
			// play error tone
			return;
		}

		Hand.InsertCardAtSlot(slot, newcard);

		RedrawAll();
		DeselectAll();
	}

	public void InvokeEquip()
	{
		Debug.Log($"Invoking Equip");


		DiscardHandSlot(SelectedHandSlot);

		var partCard = Equips.RemoveCardAtSlot(1) as PartCard;

		var oldCard = AnitaStat.SwapPart(partCard.PartType, partCard);

		Deck.AddCardToBottom(oldCard);

		DeselectAll();
		RedrawAll();
	}

	public void InvokeCombine()
	{
		Debug.Log($"Invoking Combine");

		int blessingSlot = SelectedHandSlot;
		DiscardHandSlot(blessingSlot);

		var combines = Combines.GetAllActiveCards();
		Combines.RemoveAllCards();

		if(combines.First().CardType == CardType.Gene)
		{
			int oldTier = 6;
			foreach (var card in combines)
			{
				var genecard = card as GeneCard;
				if ((int)genecard.Tier < oldTier)
				{
					oldTier = (int)genecard.Tier;
				}
			}

			GeneTier newtier = GeneTier.Two;

			if (oldTier == (int)GeneTier.Two)
			{
				int rand = Random.Range((int)GeneTier.Alpha, (int)GeneTier.Ultimate);
				newtier = (GeneTier)rand;
			}
			else if(oldTier == (int)GeneTier.Alpha || oldTier == (int)GeneTier.Beta || oldTier == (int)GeneTier.Gamma)
			{
				newtier = GeneTier.Ultimate;
			}

			var newcard = CardDefinitions.GeneCards.Where(x => x.Tier == newtier).First();

			if (newcard == null)
				Debug.Log("wtf man");

			Hand.InsertCardAtSlot(blessingSlot, newcard);
		}
		//else if(combines.First().CardType == CardType.Part)
		//{
		//	foreach (var card in combines)
		//	{
		//		var genecard = card as GeneCard;
		//		if ((int)genecard.Tier < oldTier)
		//		{
		//			oldTier = (int)genecard.Tier;
		//		}
		//	}
		//}

		DeselectAll();
		RedrawAll();
	}

	public void InvokeInfuse()
	{
		Debug.Log($"Invoking Infuse");

		int blessingSlot = SelectedHandSlot;
		DiscardHandSlot(blessingSlot);

		var oldPart = Infuses.GetCardAtSlot(1) as PartCard;
		var oldGene = Infuses.GetCardAtSlot(2) as GeneCard;

		Infuses.RemoveAllCards();

		var newcard = CardDefinitions.PartCards.Where(x => x.Tier == oldGene.Tier && x.PartType == oldPart.PartType).First();

		if (newcard == null)
			Debug.Log("wtf man");

		Hand.InsertCardAtSlot(blessingSlot, newcard);

		DeselectAll();
		RedrawAll();
	}
}
