using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HoverShowInterior : MonoBehaviour {

    public GameObject button;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    //public GameObject button5;
    private MeshRenderer buttonRenderer;
    private MeshRenderer buttonRenderer1;
    private MeshRenderer buttonRenderer2;
    private MeshRenderer buttonRenderer3;
    private MeshRenderer buttonRenderer4;
    //private MeshRenderer buttonRenderer5;

    private MeshRenderer cornersRenderer;

    // Use this for initialization
    void Start() {
        buttonRenderer = button.GetComponent<MeshRenderer>();
        buttonRenderer1 = button1.GetComponent<MeshRenderer>();
        buttonRenderer2 = button2.GetComponent<MeshRenderer>();
        buttonRenderer3 = button3.GetComponent<MeshRenderer>();
        buttonRenderer4 = button4.GetComponent<MeshRenderer>();
        //buttonRenderer5 = button5.GetComponent<MeshRenderer>();

        cornersRenderer = GetComponent<MeshRenderer>();

        buttonRenderer.enabled = false;
        buttonRenderer1.enabled = false;
        buttonRenderer2.enabled = false;
        buttonRenderer3.enabled = false;
        buttonRenderer4.enabled = false;
        //buttonRenderer5.enabled = false;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnHandHoverBegin(Hand hand) {
        buttonRenderer.enabled = true;
        buttonRenderer1.enabled = true;
        buttonRenderer2.enabled = true;
        buttonRenderer3.enabled = true;
        buttonRenderer4.enabled = true;
        //buttonRenderer5.enabled = true;

        cornersRenderer.enabled = false;
    }

    //private void OnHandHoverEnd(Hand hand) {
    //    buttonRenderer.enabled = false;
    //    buttonRenderer1.enabled = false;
    //    buttonRenderer2.enabled = false;
    //    buttonRenderer3.enabled = false;
    //    buttonRenderer4.enabled = false;
    //    //buttonRenderer5.enabled = false;
    //}
}
