using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dolan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3 (-3f * Time.deltaTime, 0,0);	
	}
}
