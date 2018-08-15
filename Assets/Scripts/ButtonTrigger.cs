using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour {

    //private Transform boxPrefab;

    //private Transform spawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "ButtonFace") {
            print("buttoned!");
        }
    }
}
