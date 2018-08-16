using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeToFitDrawers : MonoBehaviour {

    public GameObject contents;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResizeMask() {
        Vector3 sizeCalculated = contents.GetComponent<Renderer>().bounds.size;
        transform.localScale = sizeCalculated;
        print("processed");
    }
}
