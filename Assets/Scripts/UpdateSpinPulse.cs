using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpinPulse : MonoBehaviour 
{
    public enum SpinState { Accel, Decel, Stop };

    private float elapsedTime = 0f;
    private SpinState state = SpinState.Accel;

    private SpriteRenderer sRender;
    private Color origColor;

    private float fadeCounter = 0f;

    void Start()
    {
        sRender = GetComponent<SpriteRenderer>();
        origColor = sRender.color;
    }

	// Update is called once per frame
	void Update () 
    {
        elapsedTime += Time.deltaTime;
        fadeCounter += Time.deltaTime;
        
        if(state == SpinState.Accel)
        {
            transform.Rotate(0f, 0f, 2f * Mathf.Exp(elapsedTime));

            if (fadeCounter > 0.1f)
            {
                if (elapsedTime < 3.2f)
                    sRender.color = new Color(origColor.r, origColor.g, origColor.b, 0.65f * (elapsedTime / 4.0f));
                else if (elapsedTime > 3.6f)
                    sRender.color = new Color(origColor.r, origColor.g, origColor.b, 1f);
            }
            
            if (elapsedTime > 4.0f) state = SpinState.Decel;
        }
        else if(state == SpinState.Decel)
        {
            transform.Rotate(0f, 0f, 2f * Mathf.Exp(8.0f - elapsedTime));

            if(fadeCounter > 0.1f)
                sRender.color = new Color(origColor.r, origColor.g, origColor.b, Mathf.Pow((8.0f - elapsedTime) / 4.0f, 2.0f));

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

        if (fadeCounter > 0.1f) fadeCounter = 0f;
	}
}
