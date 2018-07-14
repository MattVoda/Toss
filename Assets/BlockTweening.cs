using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTweening : MonoBehaviour {

    public float maxWidth = 1f; //block resides in parent with ScaleX=5. So 1=5
    public GameObject pin; //for getting pin position when collapsing

    private Vector3 initialPosition;
    private Vector3 initialSize;
    private Vector3 initialScale;
    private Vector3 maxScale;
    private float timeScale = 6f;
    private Vector3 parentScale;
    private Vector3 parentPosition;
    private float sliderValue = 50f;
    private float sliderValueMax = 100f;
    private float sliderValueMin = 0f;

    private Vector3 positionBeforeMoving;
    private float subtractiveZ;
    private float subtractiveY;
    Vector3 correctedPinPos;

    // Use this for initialization
    void Start () {
        initialPosition = transform.position;
        initialSize = gameObject.GetComponent<Renderer>().bounds.size;
        initialScale = gameObject.transform.localScale;
        maxScale = new Vector3(maxWidth, initialScale.y, initialScale.z);

        parentPosition = transform.parent.transform.position;
        parentScale = transform.parent.transform.localScale;

        subtractiveZ = initialSize.z / 2;
        subtractiveY = initialSize.y / 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Expand(Vector3 pinPosition) {
        //iTween.ScaleTo(gameObject, iTween.Hash(
        //     "x", maxWidth,
        //     "time", .3,
        //     "easeType", iTween.EaseType.easeOutSine
        //));

        float subPinX = pinPosition.x;
        float subPinY = pinPosition.y - subtractiveY;
        float subPinZ = pinPosition.z + subtractiveZ;

        correctedPinPos = new Vector3(subPinX, subPinY, subPinZ);
        positionBeforeMoving = transform.position;

        StartCoroutine(ExpandCoroutine(correctedPinPos));
    }

    IEnumerator ExpandCoroutine(Vector3 pinPosition) {
        float progress = 0;

        //while (transform.localScale.x < maxWidth) {
        while (progress <= 1) {
            transform.localScale = Vector3.Lerp(initialScale, maxScale, progress);
            transform.position = Vector3.Lerp(positionBeforeMoving, pinPosition, progress);
            progress += Time.deltaTime * timeScale;
            yield return null;
        }
        transform.localScale = maxScale;
    }

    public void Contract(Vector3 pinPosOnRelease) {
        //iTween.ScaleTo(gameObject, iTween.Hash(
        //     "x", initialSize.x,
        //     "time", .3,
        //     "easeType", iTween.EaseType.easeOutSine
        //));

        float subPinX = pinPosOnRelease.x;
        float subPinY = pinPosOnRelease.y - subtractiveY;
        float subPinZ = pinPosOnRelease.z + subtractiveZ;

        correctedPinPos = new Vector3(subPinX, subPinY, subPinZ);
        positionBeforeMoving = transform.position;

        StartCoroutine(ContractCoroutine(correctedPinPos));
    }

    IEnumerator ContractCoroutine(Vector3 pinPos) {
        float progress = 0;
        
        while (progress <= 1) {
            transform.localScale = Vector3.Lerp(maxScale, initialScale, progress);
            transform.position = Vector3.Lerp(positionBeforeMoving, pinPos, progress);
            progress += Time.deltaTime * timeScale;
            yield return null;
        }
        transform.localScale = initialScale;
    }
}
