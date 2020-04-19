using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public struct Message
{
  public string Text;
  public float TimeDisplay;
}

public class DisplayText : MonoBehaviour
{
  public List<Message> Messages;

  public float FadeOutTime;

  public float FadeInTime;

  public TMP_Text TextBox;

  public Image FadeOutMask;


  private bool skip = false;

  void Start()
  {
    StartCoroutine(ShowAllMessages());
    TextBox.text = "";
    FadeOutMask.color = Color.clear;
  }

  void Update()
  {
    if(Input.GetMouseButtonDown(0))
    {
      skip = true;
    }
  }

  IEnumerator ShowAllMessages()
  {
    yield return new WaitForSeconds(0.1f);

    foreach(var message in Messages)
    {
      skip = false;
      yield return CrossFade(TextBox, FadeOutTime, FadeInTime, message.Text);

      for (float t = 0.01f; t < message.TimeDisplay; t += Time.deltaTime)
      {
        if (skip)
        {
          break;
        }
        yield return null;
      }
    }

    yield return SceneFadeout(FadeOutTime);

    SceneManager.LoadScene("Tutorial");
  }

  IEnumerator CrossFade(TMP_Text text, float fadeout, float fadein, string newText)
  {
    Color originalColor = text.color;
    for (float t = 0.01f; t < fadeout; t += Time.deltaTime)
    {
      if(skip)
      {
        text.color = Color.clear;
        break;
      }
      text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeout));
      yield return null;
    }

    text.text = newText;

    for (float t = 0.01f; t < fadein; t += Time.deltaTime)
    {
      if (skip)
      {
        text.color = originalColor;
        break;
      }
      text.color = Color.Lerp(Color.clear, originalColor, Mathf.Min(1, t / fadein));
      yield return null;
    }
  }


  IEnumerator SceneFadeout(float fadeout)
  {
    for (float t = 0.01f; t < fadeout; t += Time.deltaTime)
    {
      FadeOutMask.color = Color.Lerp(Color.clear, Color.black, Mathf.Min(1, t / fadeout));
      yield return null;
    }
  }
}
