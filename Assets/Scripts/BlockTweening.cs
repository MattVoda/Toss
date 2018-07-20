using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTweening : MonoBehaviour {

    public float maxWidth = 5f; 
    public GameObject pin; //for getting pin position when collapsing

    private Vector3 initialPosition;
    private Vector3 initialSize;
    private Vector3 initialScale;
    private Vector3 maxScale;
    private float timeScale = 6f;
    //private Vector3 parentScale;
    //private Vector3 parentPosition;
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

        subtractiveZ = initialSize.z / 2;
        subtractiveY = initialSize.y / 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Expand(Vector3 pinPosition) {
        float subPinX = pinPosition.x;
        float subPinY = pinPosition.y - subtractiveY;
        float subPinZ = pinPosition.z + subtractiveZ;

        correctedPinPos = new Vector3(subPinX, subPinY, subPinZ);
        positionBeforeMoving = transform.position;

        StartCoroutine(ExpandCoroutine(correctedPinPos));
    }

    IEnumerator ExpandCoroutine(Vector3 pinPosition) {
        float progress = 0;
        
        while (progress <= 1) {
            transform.localScale = Vector3.Lerp(initialScale, maxScale, progress);
            transform.position = Vector3.Lerp(positionBeforeMoving, initialPosition, progress);
            progress += Time.deltaTime * timeScale;
            yield return null;
        }
        //transform.localScale = maxScale;
    }

    public void Contract(Vector3 pinPosOnRelease) {

        float subPinX = pinPosOnRelease.x;
        float subPinY = pinPosOnRelease.y - subtractiveY;
        float subPinZ = pinPosOnRelease.z + subtractiveZ;

        correctedPinPos = new Vector3(subPinX, subPinY, subPinZ);
        positionBeforeMoving = transform.position;

        StartCoroutine(ContractCoroutine(correctedPinPos));

        //if (pinPosOnRelease.x != transform.position.x) {
            
        //    StartCoroutine(MovePinToCorrect(pin.transform.position, transform.position));
        //}
    }

    IEnumerator ContractCoroutine(Vector3 pinPos) {
        float progress = 0;
        
        while (progress <= 1) {
            transform.localScale = Vector3.Lerp(maxScale, initialScale, progress);
            transform.position = Vector3.Lerp(positionBeforeMoving, pinPos, progress);
            progress += Time.deltaTime * timeScale;
            yield return null;
        }
        //transform.localScale = initialScale;
    }

    IEnumerator MovePinToCorrect(Vector3 currentPinPos, Vector3 currentBlockPosition) {
        float progress = 0;

        while (progress <= .3f) {
            pin.transform.position = Vector3.Lerp(currentPinPos, new Vector3(currentPinPos.x, currentPinPos.y, currentPinPos.z), progress);
            progress += Time.deltaTime * timeScale;
            yield return null;
        }
        //transform.localScale = initialScale;
    }
}
