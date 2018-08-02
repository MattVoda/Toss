using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPosition : MonoBehaviour {
    
    public Transform buttonFace;
    public Transform back;
    public float minZ;
    public float maxZ;
    public float[] anchorPoints;
    public float snapDistance = 0.05f;

	// Use this for initialization
	void Start () {
        buttonFace = gameObject.transform;
        minZ = transform.position.y;
        maxZ = back.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SnapPosition() {
        //Cycle through each predefined anchor point
        for (int i = 0; i < anchorPoints.Length; i++) {
            //If lever is within "snapping distance" of that anchor point
            if (Mathf.Abs(buttonFace.localPosition.z - anchorPoints[i]) < snapDistance) {
                //Get current lever position and update z pos to anchor point
                Vector3 position = buttonFace.transform.localPosition;
                position.z = anchorPoints[i];
                buttonFace.transform.localPosition = position;

                //Break so it stops checking other anchor points
                break;
            }
        }
    }
}
