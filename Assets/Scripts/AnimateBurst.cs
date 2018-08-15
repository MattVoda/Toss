using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBurst : MonoBehaviour {

    public GameObject back;
    public GameObject buttonFace;
    public Animator animController;
    private LayoutGroup3D sunburst;

    public float burstDistance = 0.25f;
    public float snapDistance = 0.05f;

    private float distance;

    // Use this for initialization
    void Start() {
        animController = GetComponent<Animator>();
        sunburst = GetComponentInParent<LayoutGroup3D>();
    }

    // Update is called once per frame
    void Update() {
        distance = Vector3.Distance(back.transform.position, buttonFace.transform.position);
        //print(transform.position);
        //print("distance= " + distance);
        if (Mathf.Abs(distance - burstDistance) < snapDistance) {
            //print("animation!");
            animController.SetTrigger("Step1");
            sunburst.RebuildLayout();
        } else {
            animController.ResetTrigger("Step1");
        }
    }
}
