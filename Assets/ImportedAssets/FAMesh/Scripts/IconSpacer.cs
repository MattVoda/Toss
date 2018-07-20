using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSpacer : MonoBehaviour {


    public GameObject[] RightColumn;
    public GameObject[] LeftColumn;
    public float Spacing = 3.5f;

    public float rotateSpeed = 1f;
    public float rotateAmount = .5f;
	void Start () {

        float z = 0f;       
        foreach (var go in RightColumn)
        {        
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, z);
            z += Spacing;         
            
        }
        z = 0f;
        foreach(var go in LeftColumn)
        {
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, z);
            z += Spacing;           
        }
	}
	

	void Update () {

        var amt = Mathf.Sin(Time.time) * rotateAmount;
        var scaleAmt = Mathf.Sin(Time.time) / 200f;
        for (int i = 0; i < LeftColumn.Length; i++)
        {
            LeftColumn[i].transform.Rotate(Vector3.up, amt);
            LeftColumn[i].transform.localScale += new Vector3(scaleAmt , scaleAmt, scaleAmt);
        }

        for (int i = 0; i < RightColumn.Length; i++)
        {
            RightColumn[i].transform.Rotate(Vector3.up, -amt);
            RightColumn[i].transform.localScale += new Vector3(scaleAmt, scaleAmt, scaleAmt);
        }

    }
}
