using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectColor : MonoBehaviour {
    public GameObject[] colors;
	// Use this for initialization
	void Start () {
        int color = (int)(Random.Range(0f, 3f)-0.01);
        if (color == 0)
            colors[0].SetActive(true);
        if (color == 1)
            colors[1].SetActive(true);
        if (color == 2)
            colors[2].SetActive(true);
	}
}
