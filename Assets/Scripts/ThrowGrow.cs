using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrow : MonoBehaviour {

    public float minScale;
    public float maxScale;



    private Vector3 distanceVector;



    public SteamVR_Camera HMD;


    [Header("Menu Options")]
    public Vector3 startPosition;
    public float minimumPullDistance = 0.5f; // instantiates and destroy at this distance
    public float interpMultiplier = 1f;
    public float tweeningTime = 0.1f;
    public bool LookAtHMD = false;

    [Header("Prefabs")]
    public GameObject folderPrefab;
    public GameObject filePrefab;

    private void Awake() {
       startPosition = transform.position;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        distanceVector = transform.position - HMD.transform.position;
        print(distanceVector);
    }
}
