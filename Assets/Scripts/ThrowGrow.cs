using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ThrowGrow : MonoBehaviour {

    public Vector3 maxScaleVector = new Vector3(0.25f, 0.25f, 0.25f);
    public Vector3 minScaleVector = new Vector3(0.1f, 0.1f, 0.1f);

    private float distance;
    private float dampedDistance;
    public float distanceDampener = 0.5f;
    private Vector3 clampedScaleVector;

    private bool popped = false;

    [Header("Menu Options")]
    //public float minimumPullDistance = 0.5f; // instantiates and destroy at this distance
    public float tweeningTime = 0.2f;
    public bool LookAtHMD = false;
    private Vector3 startPosition;

    [Header("Prefabs")]
    public GameObject folderPrefab;
    public GameObject filePrefab;
    public SteamVR_Camera HMD;
    public Material deployedColor;
    private Renderer rend;

    private void Awake() {
       startPosition = transform.position;
    }

    void Start () {
        rend = GetComponent<Renderer>();
	}
	
	void Update () {
        distance = Vector3.Distance(transform.position, HMD.transform.position);

    }

    private void OnDetachedFromHand(Hand hand) {
        print("thrown!");
        iTween.ScaleTo(gameObject, maxScaleVector, tweeningTime);
        rend.material.color = Color.gray;
    }
    private void OnAttachedToHand(Hand hand) {
        print("picked up!");
        iTween.ScaleTo(gameObject, minScaleVector, tweeningTime);
        rend.material.color = Color.white;
    }
}
