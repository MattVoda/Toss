using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ColorButton : MonoBehaviour {

    public Material material;
    public GameObject enviroCube;
    private MeshRenderer enviroRenderer;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material = material;
        enviroRenderer = enviroCube.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnHandHoverBegin(Hand hand) {
        enviroRenderer.material = material;
    }
}
