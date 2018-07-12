using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encircle : MonoBehaviour {

    // Instantiates a prefab in a circle around a specific point (shieldGen)
    public GameObject prefab;
    public int numberOfObjects = 10;
    public GameObject selector_sphere;
    private Transform content_sphere;
    public float startRadius = 0.01f;
    public float endRadius = 0.3f;
    public SteamVR_Camera HMD;


    void Start() {
        
        content_sphere = gameObject.transform;
        iTween.ScaleTo(gameObject, new Vector3(startRadius, startRadius, startRadius), 0f);

        for (int i = 0; i < numberOfObjects; i++) {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * endRadius;
            Instantiate(prefab, selector_sphere.transform.position + pos, Quaternion.identity, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(HMD.transform);
	}

    public void Expand() {
        iTween.ScaleTo(gameObject, new Vector3(endRadius, endRadius, endRadius), 1f);
    }
}
