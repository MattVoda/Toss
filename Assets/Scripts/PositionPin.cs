using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPin : MonoBehaviour {

    public GameObject pin;
    public GameObject block;
    private Renderer blockRenderer;
    private Vector3 blockSize;
    private Vector3 centerMidTopEdge;

	// Use this for initialization
	void Start () {
        blockRenderer = block.GetComponent<Renderer>();
        blockSize = blockRenderer.bounds.size;
        print(blockSize);

        FindMidpointOnTopEdge();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FindMidpointOnTopEdge() {
        float additionalZ = blockSize.z / 2;
        float additionalY = blockSize.y / 2;

        float pinX = block.transform.position.x;
        float pinY = block.transform.position.y + additionalY;
        float pinZ = block.transform.position.z - additionalZ;

        centerMidTopEdge = new Vector3(pinX, pinY, pinZ);

        TranslatePin();
    }

    void TranslatePin() {
        pin.transform.position = centerMidTopEdge;
    }
}
