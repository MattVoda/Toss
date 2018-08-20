using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    private Transform stuff; // Needs rigidbody attached with a collider
    private Rigidbody rb;
    Vector3 vel; // Holds the random velocity
    float switchDirection = 3f;
    float curTime = 0f;

	// Use this for initialization
	void Start() {
        stuff = gameObject.transform;
        rb = stuff.GetComponent<Rigidbody>();
        SetVel();
    }

    // Update is called once per frame
    void Update() {
        if (curTime < switchDirection) {
            curTime += 1 * Time.deltaTime;
        } else {
            SetVel();
            if (Random.value > .5) {
                switchDirection += Random.value;
            } else {
                switchDirection -= Random.value;
            }
                if (switchDirection < 1) {
                    switchDirection = 1 + Random.value;
                }
                curTime = 0;
            }
        }

    void FixedUpdate() {
        rb.velocity = vel;
    }

    void SetVel() {
        //print(Random.value);
        if (Random.value > .5) {
            vel.x = 10 * .2f * Random.value;
        } else {
            vel.x = -10 *.2f * Random.value;
        }
        //if (Random.value > .5) {
        //    vel.y = 10 * 1 * Random.value;
        //} else {
        //    vel.y = -10 * 1 * Random.value;
        //}
    }
}
