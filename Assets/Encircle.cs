using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encircle : MonoBehaviour {

    // Instantiates a prefab in a circle around a specific point (shieldGen)
    public GameObject prefab;
    public int numberOfObjects = 10;
    private Transform sphere;
    public float radius = 1f;

    void Start() {

        sphere = gameObject.transform;

        for (int i = 0; i < numberOfObjects; i++) {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            Instantiate(prefab, sphere.position + pos, Quaternion.identity, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
