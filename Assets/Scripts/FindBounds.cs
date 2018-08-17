using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //print(FigureBounds());
	}

    public Vector3 FigureBounds() {
        // First find a center for your bounds.
        Vector3 center = Vector3.zero;

        foreach (Transform child in gameObject.transform) {
            center += child.GetComponent<Renderer>().bounds.center;
        }
        center /= gameObject.transform.childCount; //center is average center of children

        //Now you have a center, calculate the bounds by creating a zero sized 'Bounds', 
        Bounds bounds = new Bounds(center, Vector3.zero);

        foreach (Transform child in gameObject.transform) {
            bounds.Encapsulate(child.GetComponent<Renderer>().bounds);
        }

        Bounds parentHandleBounds = transform.parent.GetComponent<Renderer>().bounds;
        bounds.Encapsulate(parentHandleBounds);

        return bounds.size;
    }
}
