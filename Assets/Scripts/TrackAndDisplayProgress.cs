using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAndDisplayProgress : MonoBehaviour {

    public GameObject min;
    public GameObject max;
    public GameObject percentageGO;
    private TextMesh percentageTextMesh;
    private Vector3 minPos;
    private Vector3 maxPos;
    private float minMaxDistance;
    private float minPinDistance;
    private float value;

	// Use this for initialization
	void Start () {
        percentageTextMesh = percentageGO.GetComponent<TextMesh>();
        minPos = min.transform.position;
        maxPos = max.transform.position;
        minMaxDistance = Vector3.Distance(minPos, maxPos);

        print("minPos = " + minPos);
        print("maxPos = " + maxPos);
        print("minMaxDistance = " + minMaxDistance);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CalculatePercentage() {
        minPinDistance = Vector3.Distance(minPos, transform.position);
        value = Mathf.Round((minPinDistance / minMaxDistance) * 100);
        string percentageText = value + "%";
        percentageTextMesh.text = percentageText;

        print("minPinDistance = " + minPinDistance);
    }
}
