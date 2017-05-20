using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSpin : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
        StartCoroutine(SpinHeroesOfTheStorm());
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
}
