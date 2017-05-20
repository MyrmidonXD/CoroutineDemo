using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSpinPulse : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(SpinHeroesOfTheStorm());
        StartCoroutine(PulseHeroesOfTheStorm());
	}
	
	IEnumerator SpinHeroesOfTheStorm()
    {
        while(true)
        {
            yield return StartCoroutine(SpinAccelDecel(8.0f));
            yield return new WaitForSeconds(2.0f);
        }
    }
    
    IEnumerator SpinAccelDecel(float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < (duration/2.0f))
        {
            elapsedTime += Time.deltaTime;
            transform.Rotate(0f, 0f, 2f * Mathf.Exp(elapsedTime));
            yield return null;
        }
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.Rotate(0f, 0f, 2f * Mathf.Exp(duration - elapsedTime));
            yield return null;
        }
    }
    IEnumerator PulseHeroesOfTheStorm()
    {
        while (true)
        {
            yield return StartCoroutine(PulseFadeIn(4.0f));
            yield return StartCoroutine(PulseFadeOut(4.0f));
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator PulseFadeIn(float duration)
    {
        SpriteRenderer sRender = GetComponent<SpriteRenderer>();
        Color origColor = sRender.color;
        sRender.color = new Color(origColor.r, origColor.g, origColor.b, 0f);

        float elapsedTime = 0f;
        while (elapsedTime / duration < 0.8f)
        {
            sRender.color = new Color(origColor.r, origColor.g, origColor.b, 0.65f * (elapsedTime / duration));
            elapsedTime += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.1f * duration);
        sRender.color = new Color(origColor.r, origColor.g, origColor.b, 1f);
        yield return new WaitForSeconds(0.1f * duration);
    }
    IEnumerator PulseFadeOut(float duration)
    {
        SpriteRenderer sRender = GetComponent<SpriteRenderer>();
        Color origColor = sRender.color;
        sRender.color = new Color(origColor.r, origColor.g, origColor.b, 1f);

        float remainingTime = duration;
        while (remainingTime > 0f)
        {
            sRender.color = sRender.color = new Color(origColor.r, origColor.g, origColor.b, Mathf.Pow(remainingTime / duration, 2.0f));
            remainingTime -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.1f);
    }
}
