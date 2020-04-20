using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHandler : MonoBehaviour
{
	public Hand HandManager;

	public int SelectedSlot = 0;
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

	// Start is called before the first frame update
	void Start()
	{
		EventSystem = EventSystem.current;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void SelectHandSlot(int slot)
	{
		if(SelectedSlot == slot)
		{
			EventSystem.SetSelectedGameObject(null);
			SelectedSlot = 0;
		}
		else
		{
			SelectedSlot = slot;
		}
	}

	public void SelectEquipSlot()
	{

	}

	public void SelectCombineSlot(int slot)
	{

	}

	public void SelectInfuseSlot(int slot)
	{

	}
}
