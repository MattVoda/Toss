using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTweening : MonoBehaviour {

    public float maxWidth = 1f; //block resides in parent with ScaleX=5. So 1=5
    public GameObject pin; //for getting pin position when collapsing

    private Vector3 initialPosition;
    private Vector3 initialSize;
    private Vector3 parentScale;
    private Vector3 parentPosition;
    private float sliderValue = 50f;
    private float sliderValueMax = 100f;
    private float sliderValueMin = 0f;

    // Use this for initialization
    void Start () {
        initialPosition = transform.position;
        initialSize = gameObject.GetComponent<Renderer>().bounds.size;

        parentPosition = transform.parent.transform.position;
        parentScale = transform.parent.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Expand() {
        iTween.ScaleTo(gameObject, iTween.Hash(
             "x", maxWidth,
             "time", .3,
             "easeType", iTween.EaseType.easeOutSine
        ));
    }
}
