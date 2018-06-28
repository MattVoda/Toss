using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class FileResponseToHover : MonoBehaviour
{
    private Renderer rend;
    private Animator anim;
    private int transitionTriggerBool = Animator.StringToHash("engaged");


    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnHandHoverBegin(Hand hand) {
        if (hand.currentAttachedObject.tag == "selector") {
            //print("hovering with sphere!");

            //rend.material.color = Color.red;
            //anim.Play(allHash);
            anim.SetBool(transitionTriggerBool, true);
        }
    }

    private void HandHoverUpdate(Hand hand) {
        
        
    }

    private void OnHandHoverEnd(Hand hand) {
        if (hand.currentAttachedObject.tag == "selector") {
            anim.SetBool(transitionTriggerBool, false);
        }
    }
}
