using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPin : MonoBehaviour {

    public GameObject pin;
    public GameObject block;
    public GameObject min;
    public GameObject max;
    private Renderer blockRenderer;
    private Vector3 blockSize;
    private Vector3 centerMidTopEdge;
    private float additionalZ;
    private float additionalY;

    // Use this for initialization
    void Start () {
        blockRenderer = block.GetComponent<Renderer>();
        blockSize = blockRenderer.bounds.size;

        FindMidpointOnTopEdge();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FindMidpointOnTopEdge() {
        additionalZ = blockSize.z / 2;
        additionalY = blockSize.y / 2;

        float pinX = block.transform.position.x;
        float pinY = block.transform.position.y + additionalY;
        float pinZ = block.transform.position.z - additionalZ;

        centerMidTopEdge = new Vector3(pinX, pinY, pinZ);

        TranslatePin();
        TranslateMinMax();
    }

    void TranslatePin() {
        pin.transform.position = centerMidTopEdge;
    }

    void TranslateMinMax() {
        min.transform.position = new Vector3(min.transform.position.x, min.transform.position.y + additionalY, min.transform.position.z - additionalZ);
        max.transform.position = new Vector3(max.transform.position.x, max.transform.position.y + additionalY, max.transform.position.z - additionalZ);
    }
}
