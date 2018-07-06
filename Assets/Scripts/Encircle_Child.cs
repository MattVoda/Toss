using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR.InteractionSystem;

public class Encircle_Child : MonoBehaviour
{

    // Instantiates a prefab in a circle around a specific point (shieldGen)
    public GameObject basecube_prefab;
    public GameObject kidcube_prefab;
    public int numberOfObjects = 10;
    public GameObject selector_sphere;
    public GameObject content_sphere;
    public float startRadius = 0.01f;
    public float endRadius = 0.15f;  //of imaginary circle
    public SteamVR_Camera HMD;

    private bool attached = true;
    private GameObject[] files;

    void Start() {
        files = new GameObject[numberOfObjects];

        content_sphere.transform.localPosition = selector_sphere.transform.localPosition;
        iTween.ScaleTo(content_sphere, new Vector3(startRadius, startRadius, startRadius), 0f);

        for (int i = 0; i < numberOfObjects; i++) {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * endRadius;
            files[i] = Instantiate(kidcube_prefab, selector_sphere.transform.position + pos, Quaternion.identity, content_sphere.transform);
        }
    }

    // Update is called once per frame
    void Update() {
        if (attached) {
            content_sphere.transform.position = selector_sphere.transform.position;
        }
        
        content_sphere.transform.LookAt(HMD.transform);
    }

    public void Expand() {
        attached = false;
        iTween.ScaleTo(content_sphere, new Vector3(endRadius, endRadius, endRadius), 0.5f);
        StartCoroutine(WaitToStartInteractivity());
        ActivateInteractivity();
    }

    public void Contract() {
        attached = true;
        iTween.ScaleTo(content_sphere, new Vector3(startRadius, startRadius, startRadius), 0.5f);
    }

    IEnumerator WaitToStartInteractivity() {
        yield return new WaitForSecondsRealtime(1);
    }

    public void ActivateInteractivity() {
        for (int i = 0; i < numberOfObjects; i++) {
            files[i].GetComponent<KidResponseToHover>().enabled = true;
        }
    }
}
