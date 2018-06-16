using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DrawRing : MonoBehaviour {

    private Vector3 center;
    private GameObject ring;
    private bool ringExistant = false;

    public GameObject torusPrefab;
    private Dest.Modeling.Torus torusScriptRef;
    private GameObject torus;
    public Vector3 ringScale;

	// Use this for initialization
	void Start () {
        center = transform.position;
        Torus();
    }
	
	// Update is called once per frame
	void Update () {
        center = transform.position;
        
    }

    void Torus() {
        torus = Instantiate<GameObject>(torusPrefab, center, Quaternion.identity, gameObject.transform);
        //iTween to 1,1,1 scale to grow out from sphere!

        iTween.ScaleTo(torus, new Vector3(0f, 0f, 0f), 0f);
        iTween.RotateTo(torus, new Vector3(-90f, 0f, 0f), 0f);
    }

    private void OnAttachedToHand(Hand hand) {
        iTween.ScaleTo(torus, new Vector3(0f, 0f, 0f), 1f);
    }
    private void OnDetachedFromHand(Hand hand) {
        iTween.ScaleTo(torus, new Vector3(1f, 1f, 1f), 1f);
    }
}
