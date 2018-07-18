using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ColorButton : MonoBehaviour {

    public Material material;
    public GameObject enviroCube;
    public GameObject enviroCube1;
    public GameObject enviroCube2;
    private MeshRenderer enviroRenderer;
    private MeshRenderer enviroRenderer1;
    private MeshRenderer enviroRenderer2;

    // Use this for initialization
    void Start () {
        GetComponent<MeshRenderer>().material = material;
        enviroRenderer = enviroCube.GetComponent<MeshRenderer>();
        enviroRenderer1 = enviroCube1.GetComponent<MeshRenderer>();
        enviroRenderer2 = enviroCube2.GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnHandHoverBegin(Hand hand) {
        enviroRenderer.material = material;
        enviroRenderer1.material = material;
        enviroRenderer2.material = material;
    }
}
