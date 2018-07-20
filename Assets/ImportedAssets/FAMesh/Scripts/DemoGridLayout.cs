using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoGridLayout : MonoBehaviour {

    public GameObject[] LayoutItems;
    public int GridWidth = 8;
    int GridColumns = 1;
    public float Spacing = 1f;

	// Use this for initialization
	void Start () {
        GridColumns = GridWidth / 2;
        if (LayoutItems.Length < GridWidth * GridColumns) return;
        int i = 0;
        for(int x = 0; x < GridWidth; x++)
        {
            for(int y = 0; y < GridColumns; y++)
            {
                LayoutItems[i].transform.localPosition = new Vector3(x * Spacing, y * Spacing, 0f);
                i++;
            }
        }
	}
	
}
