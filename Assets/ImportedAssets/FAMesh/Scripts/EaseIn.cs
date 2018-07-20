using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseIn : MonoBehaviour {

    public bool X;
    public bool Y;
    public bool Z;

    public float From;
    public float To;
    public float Duration = 5f;
	// Use this for initialization
	void Start () {
        StartCoroutine(EaseInFast());
	}
	
    IEnumerator EaseInFast()
    {
        this.transform.position = new Vector3(this.transform.position.x, From, this.transform.position.z); //set the FROM
        float i = 0;
        float start = Time.time;
        while(i < Duration)
        {
            i += Time.deltaTime;
            //what percent of time are we ?
            var bounce = Bounce.In(i / Duration);
            float newY = From + ((To - From) * bounce);
          // float newY = EaseInElastic(start, start + Duration, i);
            this.transform.position = new Vector3(this.transform.position.x, newY, this.transform.position.z);
            yield return new WaitForEndOfFrame();
        }        
    }

	// Update is called once per frame
	void Update () {
		
	}


    public static float EaseInElastic(float start, float end, float value)
    {
        end -= start;

        float d = 1f;
        float p = d * .3f;
        float s;
        float a = 0;

        if (value == 0) return start;

        if ((value /= d) == 1) return start + end;

        if (a == 0f || a < Mathf.Abs(end))
        {
            a = end;
            s = p / 4;
        }
        else
        {
            s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
        }

        return -(a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
    }
}


public class Bounce
{
    public static float In(float k)
    {
        return 1f - Out(1f - k);
    }

    public static float Out(float k)
    {
        if (k < (1f / 2.75f))
        {
            return 7.5625f * k * k;
        }
        else if (k < (2f / 2.75f))
        {
            return 7.5625f * (k -= (1.5f / 2.75f)) * k + 0.75f;
        }
        else if (k < (2.5f / 2.75f))
        {
            return 7.5625f * (k -= (2.25f / 2.75f)) * k + 0.9375f;
        }
        else
        {
            return 7.5625f * (k -= (2.625f / 2.75f)) * k + 0.984375f;
        }
    }

    public static float InOut(float k)
    {
        if (k < 0.5f) return In(k * 2f) * 0.5f;
        return Out(k * 2f - 1f) * 0.5f + 0.5f;
    }
};