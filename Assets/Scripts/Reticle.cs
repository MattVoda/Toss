using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour {

    public Camera hmdFacing;
    public GameObject target;
    public float reticleDistanceFromTarget = 0.5f;
    public float reticleScale = 1f;

    private Ray reticleRay;
    private Vector3 adjustedTarget;
    private float rayDistance;
    private Vector3 reticlePoint;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //positions reticle in center of vision
        //transform.position = hmdFacing.transform.position + hmdFacing.transform.rotation * Vector3.forward * 2.0f; 

        rayDistance = Vector3.Distance(hmdFacing.transform.position, target.transform.position);
        //the ray shoots at a DIRECTION, not a point. Need to subtract out HMD position to be left with relative direction.
        adjustedTarget = target.transform.position - hmdFacing.transform.position;
        reticleRay = new Ray(hmdFacing.transform.position, adjustedTarget);
        //Physics.Raycast(reticleRay, rayDistance);
        reticlePoint = reticleRay.GetPoint(rayDistance - reticleDistanceFromTarget);

        transform.position = reticlePoint;
        transform.LookAt(hmdFacing.transform.position);
        transform.Rotate(0f, 180f, 0f);
        transform.localScale = new Vector3(reticleScale, reticleScale, reticleScale);
    }
}
