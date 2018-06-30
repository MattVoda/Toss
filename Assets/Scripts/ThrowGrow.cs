using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ThrowGrow : MonoBehaviour {

    private Vector3 maxScaleVector = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 minScaleVector = new Vector3(0.05f, 0.05f, 0.05f);

    private bool fading = false;

    [Header("Menu Options")]
    public float tweeningTime = 0.2f;
    public bool LookAtHMD = false;

    [Header("Prefabs")]
    private Renderer rend;
    private MeshRenderer meshRend;
    private GameObject content_sphere;
    private GameObject sphere_system;

    private void Awake() {

    }

    void Start () {
        rend = GetComponent<Renderer>();
        meshRend = GetComponent<MeshRenderer>();
        content_sphere = gameObject.transform.parent.Find("Content_Sphere").gameObject;
        sphere_system = gameObject.transform.parent.gameObject;
	}
	
	void Update () {
        
    }

    private void OnDetachedFromHand(Hand hand) {
        iTween.ScaleTo(gameObject, maxScaleVector, tweeningTime);
        rend.material.color = Color.gray;
        
        sphere_system.GetComponent<Encircle_Child>().Expand();
    }


    private void OnAttachedToHand(Hand hand) {
        hand.HoverUnlock(null); //allows the hand to register hovering with other stuff!
        
        iTween.ScaleTo(gameObject, minScaleVector, tweeningTime);
        rend.material.color = Color.white;

    }


    public void Fade(bool fadeIn, float duration) {
        if (fading) {
            return;
        }
        fading = true;
        
        StartCoroutine(FadeTo(fadeIn, duration));
    }

    public IEnumerator FadeTo(bool fadeIn, float duration) {
        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn) {
            a = 0.1f;
            b = 1;
        } else {
            a = 1;
            b = 0.1f;
        }

        //if (!meshRend.enabled)
        //    meshRend.enabled = true;

        Color meshColor = meshRend.material.color;

        while (counter < duration) {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);
            Debug.Log(alpha);

            meshRend.material.color = new Color(meshColor.r, meshColor.g, meshColor.b, alpha);
            yield return null;
        }

        //if (!fadeIn) {
        //    //Disable Mesh Renderer
        //    meshRend.enabled = false;
        //}
        fading = false; //So that we can call this function next time
    }


}
