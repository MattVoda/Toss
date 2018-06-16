//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class July_Container : MonoBehaviour {


//    [Header("Interpolation")]
//    private GameObject[] contents;
//    public int contentsSize = 7;
//    public int numFoldersInContents = 1;

//    private Vector3 distanceVector;
//    private Vector3 segmentVector;
//    private Vector3[] interpolationVectorsArray;

//    private bool popped = false;
//    private bool rbsAdded = false;
//    private bool localPositionReset = false;
//    private GameObject originGO;
//    private SteamVR_Camera HMD;

//    [Header("File Options")]
//    public Vector3 startPosition;
//    public float minimumPullDistance = 0.5f; // instantiates and destroy at this distance
//    public float interpMultiplier = 1f;
//    public float tweeningTime = 0.1f;
//    public bool LookAtHMD = false;
//    private GameObject RedBall;

//    [Header("Prefabs")]
//    public GameObject RedBallPrefab;
//    public GameObject folderPrefab;
//    public GameObject filePrefab;
//    public GameObject originPrefab;


//    private void Awake() {
//        HMD = SteamVR_Render.Top();
//        contents = new GameObject[contentsSize];
//        interpolationVectorsArray = new Vector3[contentsSize];
//        startPosition = transform.position;
//    }

//    void Start () {
//        RedBall = Instantiate(RedBallPrefab, startPosition, Quaternion.identity, gameObject.transform);
//        originGO = Instantiate(originPrefab, startPosition, Quaternion.identity, gameObject.transform);
//        RedBall.transform.localPosition = new Vector3(0, 0, 0);
//    }
	
//	void Update () {
//        Interpolate();
//        DecideSplay();

//        if (transform.parent) {
//            Debug.Log("you have 1 parent");
//            if (transform.parent.parent) {
//                Debug.Log("you have 2 parents");
//                if (transform.parent.parent.parent) {
//                    Debug.Log("you have 3 parents");
//                    if (transform.parent.parent.parent.parent) {
//                        Debug.Log("you have 4 parents");
//                    }
//                }
//            }
//        }
//    }




//    void DecideSplay() {
//        if (distanceVector.magnitude > minimumPullDistance) {
//            if (popped) {
//                if (!rbsAdded && segmentVector.magnitude > 0.13f) {  //enable rb's on RedBall if segments are longer than radius of RedBall's collider
//                    ActivateRigidBody();
//                } else {
//                    Splay();
//                }
//            } else { // a first pop!
//                popped = true;
//                InstantiateContents();
//            }
//        } else {
//            if (popped) {
//                popped = false;
//                DestroyContents();
//            } else if (transform.parent != null && !localPositionReset) {  // hacky fix for pesky misalignment of second-level balls
//                localPositionReset = true;
//                RedBall.transform.localPosition = Vector3.zero;
//            }
//        }
//    }

//    void InstantiateContents() {
//        Vector3 tempVec = RedBall.transform.position;
//        // First instantiate all as files
//        for (int i = 0; i < contentsSize; i++) {
//            contents[i] = Instantiate(filePrefab, tempVec, Quaternion.identity, gameObject.transform) as GameObject;
//        }
//        // then overwrite with randomly-placed folders
//        int[] randFileLocations = new int[numFoldersInContents];
//        for (int j = 0; j < numFoldersInContents; j++) {
//            int randIndex = Random.Range(1, contentsSize);
//            Destroy(contents[randIndex]); //make space for folder
//            contents[randIndex] = Instantiate(folderPrefab, tempVec, Quaternion.identity, gameObject.transform) as GameObject;
//        }
//    }

//    void Interpolate() {

//        distanceVector = RedBall.transform.position - startPosition;
//        segmentVector = distanceVector / (contentsSize + 2); //+2 to shorten the segments

//        for (int i = 0; i < contentsSize; i++) {
//            interpolationVectorsArray[i].z = segmentVector.z * (i + 1) * interpMultiplier;
//            interpolationVectorsArray[i].y = segmentVector.y * (i + 1) * interpMultiplier;
//            interpolationVectorsArray[i].x = segmentVector.x * (i + 1) * interpMultiplier;
//        }
//    }


//    void Splay() {
//        for (int i = 0; i < contentsSize; i++) {
//            Vector3 temp = interpolationVectorsArray[i];
  
//            if (contents[i].tag == "Container") {
//                GameObject folderChild = contents[i];
                
//                folderChild.GetComponent<July_Container>().startPosition = contents[i].transform.position; //tell the object that its startPos to update against is its container's current pos 
//                iTween.MoveUpdate(contents[i], iTween.Hash("z", temp.z, "y", temp.y, "x", temp.x, "islocal", true, "time", tweeningTime)); //don't rotate folders - will skew deeper levels

//            } else {
//                iTween.MoveUpdate(contents[i], iTween.Hash("z", temp.z, "y", temp.y, "x", temp.x, "islocal", true, "time", tweeningTime, "looktarget", RedBall.transform.position));
//            }
//        }
//    }

//    void ActivateRigidBody() {
//        rbsAdded = true;

//        foreach (GameObject go in contents) {
//            if (go.tag == "Container") {
//                Transform t = go.transform;
//                foreach (Transform tr in t) {
//                    if (tr.tag == "Folder") {
//                        AddRigidbody(tr.gameObject);
//                        tr.gameObject.AddComponent<InteractableItem>();
//                    }
//                }
//            }
//        }
//    }

//    void AddRigidbody(GameObject recipient) {
//        Rigidbody RB = recipient.AddComponent<Rigidbody>();
//        RB.mass = 10f;
//        RB.drag = 5f;
//        RB.angularDrag = 0.05f;
//        RB.useGravity = false;
//        RB.isKinematic = false;
//        RB.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
//        RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
//    }
    


//    void DestroyContents() {
//        foreach (GameObject go in contents) {
//            GameObject.Destroy(go);
//        }
//        int childs = transform.childCount;
//        for (int i = childs - 1; i > 0; i--) {
//            GameObject.Destroy(transform.GetChild(i).gameObject);
//        }
//    }
//}

////if (transform.parent != null) {
////    print("RedBall pos = " + RedBall.transform.position);
////    print("Start pos = " + startPosition);
////    print("Distance vec = " + distanceVector);
////    print("Distance vec mag = " + distanceVector.magnitude);
////}


////if (!LookAtHMD) {
////    iTween.MoveUpdate(contents[i], iTween.Hash("z", temp.z, "y", temp.y, "x", temp.x, "islocal", true, "time", tweeningTime, "looktarget", HMD.transform.position));