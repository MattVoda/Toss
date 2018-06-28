using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class FileResponseToHover : MonoBehaviour
{
    

    private Renderer rend;


    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnHandHoverBegin(Hand hand) {
        if (hand.currentAttachedObject.tag == "selector") {
            //print("hovering with sphere!");

            rend.material.color = Color.red;

        }
    }

    private void HandHoverUpdate(Hand hand) {
        
        
    }
}
