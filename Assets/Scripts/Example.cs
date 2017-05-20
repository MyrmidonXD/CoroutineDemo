using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(HanhwaFan());
	}

    IEnumerator HanhwaFan()
    {
        while(true)
        {
            Debug.Log("나는 행복합니다");
            yield return new WaitForSeconds(8.0f);
        }
    }
}
