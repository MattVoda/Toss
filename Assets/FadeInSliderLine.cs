using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class FadeInSliderLine : MonoBehaviour {

    public GameObject sliderViz;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnHandHoverBegin(Hand hand) {
        sliderViz.GetComponent<fadeLine>().Fade(true, 0.15f);
    }

    private void OnHandHoverEnd(Hand hand) {
        sliderViz.GetComponent<fadeLine>().Fade(false, 0.5f);
    }





}
