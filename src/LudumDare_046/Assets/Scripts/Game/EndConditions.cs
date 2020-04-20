using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class EndConditions : Singleton<EndConditions>
{
	public Image WhiteOutMask;
	public float FadeoutTime = 1.0f;
	public float HangTimeBeforeExit = 1.0f;

	private void Start()
	{
		WhiteOutMask.color = Color.clear;
	}

	public void PlayerLose()
	{
		StartCoroutine(WhiteOutAndExit("You_Lose"));
	}

	IEnumerator WhiteOutAndExit(string scene)
	{
		WhiteOutMask.enabled = true;
		yield return new WaitForEndOfFrame();

		for (float t = 0.01f; t < FadeoutTime; t += Time.deltaTime)
		{
			WhiteOutMask.color = Color.Lerp(Color.clear, Color.white, Mathf.Min(1, t / FadeoutTime));
			yield return null;
		}

		yield return new WaitForSeconds(HangTimeBeforeExit);

		SceneManager.LoadScene(scene);
	}

	public void PlayerWin()
	{
		StartCoroutine(WhiteOutAndExit("You_Win"));
	}
}
