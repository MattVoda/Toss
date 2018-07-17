using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyIndicator : MonoBehaviour {

    public float Amount = .1f;

    float baseScale = 1f;
    private void Start()
    {
        baseScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update () {
        float s = Mathf.Sin(Time.time);
        transform.Translate(0f, s * Amount, 0f);
        transform.localScale = new Vector3(baseScale + s * Amount , baseScale + s * Amount , baseScale + s * Amount );
        var amt = Mathf.Sin(Time.time) * 10f;
        transform.rotation = Quaternion.Euler(0f, amt, 0f);
        //transform.Rotate(Vector3.up, amt);

    }
}
