using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cogobyte.ProceduralIndicators;

//Demo for made of shapes arrow mode in FeaturesShowCase
//Oscilates the path of arrow along x axis 
public class ArrowAnim : MonoBehaviour
{
    public ArrowObject arrowObject;
    float fi = 0;

    public Transform startPoint;
    public Transform endPoint;
    //public GameObject frontPiece;

    void Update() {
        arrowObject.arrowPath.startPoint = startPoint.transform.position;
        arrowObject.arrowPath.endPoint = new Vector3(endPoint.position.x, endPoint.position.y, endPoint.position.z * 10 * Mathf.Abs(Mathf.Sin(fi)));
        arrowObject.updateArrowMesh();
        fi += 1f * Time.deltaTime;
    }
}
