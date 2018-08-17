using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDrawers : MonoBehaviour {

    public int drawerCount = 5;
    public float spaceAdjuster = 0.05f;
    public GameObject contents;
    //public GameObject depthMasker;
    public GameObject drawerPrefab;
    public GameObject endPoint;

    private float drawerScale;
    private Vector3 contentsPos;
    private Vector3 bounds;

	// Use this for initialization
	void Start () {

        contentsPos = contents.transform.position;
        drawerScale = drawerPrefab.transform.localScale.x;

        for (int x=0; x<drawerCount; x++) {
            //Vector3 nextDrawerPos = contentsPos + new Vector3(0, 0, x - x*(1-drawerScale)); //perfectly touching, handles all prefab sizes
            //Vector3 nextDrawerPos = contentsPos + new Vector3(0, 0, x + x * spaceAdjuster); //allows gaps
            Vector3 nextDrawerPos = contentsPos + new Vector3(0, 0, x * spaceAdjuster); //allows gaps
            Instantiate<GameObject>(drawerPrefab, nextDrawerPos, contents.transform.rotation, contents.transform);
        }

        bounds = contents.GetComponent<FindBounds>().FigureBounds();
        endPoint.GetComponent<PlaceEndpoint>().PositionEndpoint(bounds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
