using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{

	public Image WhiteOutMask;

	public float FadeInTime = 1;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn()
	{
		for (float t = 0.01f; t < FadeInTime; t += Time.deltaTime)
		{
			WhiteOutMask.color = Color.Lerp(Color.white, Color.clear, Mathf.Min(1, t / FadeInTime));
			yield return null;
		}
		WhiteOutMask.enabled = false;
	}

	
	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("Main_Menu");
	}
}
