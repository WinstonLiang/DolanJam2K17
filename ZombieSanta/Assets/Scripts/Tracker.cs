using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Tracker : MonoBehaviour {

	public bool unlocked;
	public bool toggled;

	// Use this for initialization
	void Start () {
		unlocked = false;
		if(GameObject.FindGameObjectsWithTag("Tracker").Length == 1) {
			DontDestroyOnLoad(gameObject);
		}	
		else {
			Destroy(gameObject);
		}
	}

	public void SetToggled(bool t) {
		toggled = t;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
