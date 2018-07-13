using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeLine : MonoBehaviour {


    private bool fading = false;
    private MeshRenderer meshRend;

    // Use this for initialization
    void Start () {
        meshRend = GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fade(bool fadeIn, float duration) {
        if (fading) {
            return;
        }
        fading = true;

        StartCoroutine(FadeTo(fadeIn, duration));
    }

    public IEnumerator FadeTo(bool fadeIn, float duration) {
        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn) {
            a = 0f;
            b = 1;
        } else {
            a = 1;
            b = 0f;
        }

        Color meshColor = meshRend.material.color;

        while (counter < duration) {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);
            meshRend.material.color = new Color(meshColor.r, meshColor.g, meshColor.b, alpha);
            yield return null;
        }
        fading = false; //So that we can call this function next time
    }
}
