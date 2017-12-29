using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour {
    private float deathTimer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        deathTimer += Time.deltaTime;
        if (deathTimer >= 2)
            Destroy(gameObject);
	}
}
