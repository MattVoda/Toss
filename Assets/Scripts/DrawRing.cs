using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //Ring();
        Torus();
    }
	
	// Update is called once per frame
	void Update () {
        center = transform.position;
        
    }

    void Ring() {
        ring = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        ring.transform.position = center;
        ring.transform.localScale = ringScale;

        ringExistant = true;
    }

    void Torus() {
        torus = Instantiate<GameObject>(torusPrefab, center, Quaternion.identity, gameObject.transform);
        //iTween to 1,1,1 scale to grow out from sphere!

        torusScriptRef = torus.GetComponent<Dest.Modeling.Torus>();
        

        iTween.ScaleTo(torus, new Vector3(1f, 1f, 1f), 3f);
        iTween.RotateTo(torus, new Vector3(-90f, 0f, 0f), 3f);


        //these aren't working?
        torusScriptRef.Thickness = 0.01f;
        torusScriptRef.Thickness = 0.05f;
    }
}
