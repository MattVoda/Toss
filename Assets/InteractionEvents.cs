using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class InteractionEvents : MonoBehaviour {

    public GameObject block;
    private BlockTweening blockTweening;
    private TrackAndDisplayProgress trackAndDisplayProgress;
    private LinearDrive linearDrive;
    private bool currentlyFullWidth = false;
    private Vector3 pinPos;

    // Use this for initialization
    void Start () {
        blockTweening = block.GetComponent<BlockTweening>();
        trackAndDisplayProgress = GetComponent<TrackAndDisplayProgress>();
        linearDrive = GetComponent<LinearDrive>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnAttachedToHand(Hand hand) {
        
    }

    private void HandHoverUpdate(Hand hand) {
        if (hand.GetStandardInteractionButton() && !currentlyFullWidth) {
            pinPos = transform.position;
            blockTweening.Expand(pinPos);
            currentlyFullWidth = true;
        }
        trackAndDisplayProgress.CalculatePercentage();
    }

    private void OnHandHoverEnd(Hand hand) {
        if (currentlyFullWidth) {
            pinPos = transform.position;
            blockTweening.Contract(pinPos);
            trackAndDisplayProgress.CalculatePercentage();
            currentlyFullWidth = false;
        }
    }

}
