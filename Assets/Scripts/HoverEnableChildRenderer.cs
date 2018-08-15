using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HoverEnableChildRenderer : MonoBehaviour
{

    public GameObject childBox;

    private MeshRenderer boxRenderer;

    //private MeshRenderer cornersRenderer;

    // Use this for initialization
    void Start() {
        boxRenderer = childBox.GetComponent<MeshRenderer>();

        //cornersRenderer = GetComponent<MeshRenderer>();

        //boxRenderer.enabled = false;

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnHandHoverBegin(Hand hand) {
        boxRenderer.enabled = true;


        //cornersRenderer.enabled = false;
    }

    private void OnHandHoverEnd(Hand hand) {
        boxRenderer.enabled = false;
    }
}
