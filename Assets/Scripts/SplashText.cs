using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashText : MonoBehaviour
{
    public Text StartText;

    void Awake()
    {
        StartText = GetComponent<Text>();
        StartCoroutine(FadeTextToFullAlpha());
    }

    IEnumerator FadeTextToFullAlpha()
	{
        StartText.color = new Color(StartText.color.r, StartText.color.g, StartText.color.b, 0);
        while (StartText.color.a < 1.0f)
		{
            StartText.color = new Color(StartText.color.r, StartText.color.g, StartText.color.b, StartText.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZero());
	}

    IEnumerator FadeTextToZero()
	{
        StartText.color = new Color(StartText.color.r, StartText.color.g, StartText.color.b, 1);
        while (StartText.color.a > 0.0f)
        {
            StartText.color = new Color(StartText.color.r, StartText.color.g, StartText.color.b, StartText.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToFullAlpha());
    }
}
