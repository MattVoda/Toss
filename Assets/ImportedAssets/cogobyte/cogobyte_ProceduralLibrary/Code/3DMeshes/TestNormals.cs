using Cogobyte.ProceduralLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNormals : MonoBehaviour {
    public SolidMesh pgMesh;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3[] n = GetComponent<MeshFilter>().mesh.normals;
        Vector3[] v = GetComponent<MeshFilter>().mesh.vertices; 
        for (int i = 0; i < n.Length; i++)
        {
            Debug.DrawLine(v[i], v[i] + n[i], Color.red, 0.01f);
        }
    }
}
