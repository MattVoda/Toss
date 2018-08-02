using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureDistance : MonoBehaviour {


    public GameObject back;
    public GameObject buttonFace;

    private TextMesh output;
    private float distance;

	// Use this for initialization
	void Start () {
        output = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(back.transform.position, buttonFace.transform.position);
        output.text = distance.ToString();
	}
}
