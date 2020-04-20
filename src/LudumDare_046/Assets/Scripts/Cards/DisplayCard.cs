using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class DisplayCard : MonoBehaviour
{
	public Image IconImage;
	public TMP_Text Textbox;
	public Image CardBackground;
	public GameObject Border;
	public Button SelectionButton;

	public CardType CurrentState;

	private DisplayCardRepo SpriteRepo;

	// Start is called before the first frame update
	void Start()
	{
		SpriteRepo = DisplayCardRepo.Instance;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void HideCard()
	{
		IconImage.gameObject.SetActive(false);
		Textbox.gameObject.SetActive(false);
		Border.SetActive(false);
		CardBackground.CrossFadeAlpha(0.0f, 0.1f, true);
		CurrentState = CardType.None;
	}

	public void ShowCard(Card card)
	{
		if(card == null || card.CardType == CardType.None)
		{
			HideCard();
			return;
		}

		IconImage.gameObject.SetActive(true);
		Textbox.gameObject.SetActive(true);
		Border.SetActive(true);
		CardBackground.CrossFadeAlpha(1.0f, 0.1f, true);

		CurrentState = card.CardType;

		CardBackground.color = card.Color;

		switch (CurrentState)
		{
			case CardType.Gene:
				IconImage.sprite = SpriteRepo.GeneIcon;
				Textbox.fontSize = SpriteRepo.GeneTextSize;
				var geneCard = card as GeneCard;
				switch (geneCard.Tier)
				{
					case GeneTier.One:
						Textbox.text = "1";
						break;
					case GeneTier.Two:
						Textbox.text = "2";
						break;
					case GeneTier.Alpha:
						Textbox.text = "A";
						break;
					case GeneTier.Beta:
						Textbox.text = "B";
						break;
					case GeneTier.Gamma:
						Textbox.text = "G";
						break;
					case GeneTier.Ultimate:
						Textbox.text = "U";
						break;
				}
				break;
			case CardType.Part:
				IconImage.sprite = SpriteRepo.PartIcon;
				Textbox.fontSize = SpriteRepo.PartTextSize;
				var partCard = card as PartCard;
				Textbox.text = partCard.PartType.ToString();
				break;
			case CardType.Blessing:
				IconImage.sprite = SpriteRepo.BlessingIcon;
				Textbox.fontSize = SpriteRepo.BlessingTextSize;
				Textbox.text = "Blessing";
				break;
		}
	}

	public void EnableSelection()
	{
		SelectionButton.interactable = true;
	}

	public void DisableSelection()
	{
		SelectionButton.interactable = false;
	}
}
