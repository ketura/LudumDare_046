using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;

public class CombatLog : Singleton<CombatLog>
{

	public TMP_Text Textbox;


	public List<string> Items;
	public int MaxItems = 5;
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		string total = string.Join("\n", Items);
		Textbox.text = total;
	}


	public void LogItem(string text)
	{
		Debug.Log($"Combat##: {text}");
		Items.Add(text);
		if(Items.Count > MaxItems)
		{
			Items.RemoveAt(0);
		}
	}
}
