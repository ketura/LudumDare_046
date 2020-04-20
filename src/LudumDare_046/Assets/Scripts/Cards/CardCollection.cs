using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardCollection : MonoBehaviour
{
	public List<PartCard> PartCards;
	public List<GeneCard> GeneCards;

	// Start is called before the first frame update
	void Start()
	{
		PartCards = GetComponents<PartCard>().ToList();
		GeneCards = GetComponents<GeneCard>().ToList();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
