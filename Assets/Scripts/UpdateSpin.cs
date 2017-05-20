using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpin : MonoBehaviour 
{
    public enum SpinState { Accel, Decel, Stop };

    private float elapsedTime = 0f;
    private SpinState state = SpinState.Accel;

	// Update is called once per frame
	void Update () 
    {
        elapsedTime += Time.deltaTime;
        
        if(state == SpinState.Accel)
        {
            transform.Rotate(0f, 0f, 2f * Mathf.Exp(elapsedTime));
            if (elapsedTime > 4.0f) state = SpinState.Decel;
        }
        else if(state == SpinState.Decel)
        {
            transform.Rotate(0f, 0f, 2f * Mathf.Exp(8.0f - elapsedTime));
            if (elapsedTime > 8.0f) state = SpinState.Stop;
        }
        else 
        {
            if(elapsedTime > 10.0f)
            {
                elapsedTime = 0f;
                state = SpinState.Accel;
            }
        }
	}
}
