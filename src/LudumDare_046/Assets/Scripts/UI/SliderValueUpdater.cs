using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderValueUpdater : MonoBehaviour
{
	public Slider Slider;
	public TMP_Text Text;

	// Start is called before the first frame update
	void Start()
	{
		Slider = GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update()
	{
		Text.text = $"{(int)Slider.value}/{(int)Slider.maxValue}";
	}
}
