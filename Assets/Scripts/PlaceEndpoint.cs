using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceEndpoint : MonoBehaviour {

    public Transform startPoint;
    public GameObject contents;
    private float wiggleRoom = 0f;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void PositionEndpoint(Vector3 bounds) {
        Vector3 newPos = new Vector3(startPoint.transform.position.x, startPoint.transform.position.y, startPoint.transform.position.z - bounds.z);
        gameObject.transform.position = newPos;
    }
}
