using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpinPulseAsync : MonoBehaviour 
{
    public enum SpinState { Accel, Decel, Stop };
    public enum PulseState { FadeIn, FadeOut, Stop };

    private float elapsedTime = 0f;
    private float elapsedPulseTime = 0f;
    private SpinState state = SpinState.Accel;
    private PulseState pulseState = PulseState.FadeIn;

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
        
        elapsedPulseTime += Time.deltaTime;
        fadeCounter += Time.deltaTime;
        
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

        if (fadeCounter > 0.1f)
        {
            if (pulseState == PulseState.FadeIn)
            {
                if (elapsedPulseTime < 2.0f)
                    sRender.color = new Color(origColor.r, origColor.g, origColor.b, 0.65f * (elapsedPulseTime / 4.0f));
                else if (elapsedPulseTime > 2.25f)
                    sRender.color = new Color(origColor.r, origColor.g, origColor.b, 1f);

                if (elapsedPulseTime > 2.5f) pulseState = PulseState.FadeOut;
            }
            else if (pulseState == PulseState.FadeOut)
            {
                sRender.color = new Color(origColor.r, origColor.g, origColor.b, Mathf.Pow((5.0f - elapsedPulseTime) / 2.5f, 2.0f));

                if (elapsedPulseTime > 5.0f) pulseState = PulseState.Stop;
            }
            else
            {
                if (elapsedPulseTime > 6.0f)
                {
                    elapsedPulseTime = 0f;
                    pulseState = PulseState.FadeIn;
                }
            }
            
            fadeCounter = 0f;
        }
	}
}
