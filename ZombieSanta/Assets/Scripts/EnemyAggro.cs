using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.tag == "Enemy") {
			if(other.gameObject.GetComponent<chasePlayer>() != null && other.gameObject.GetComponent<chasePlayer>().aggro) {
				transform.parent.gameObject.GetComponent<chasePlayer>().aggro = true;
				transform.parent.gameObject.GetComponent<Animator>().SetBool("moving", true);
			}
		}
	}
}
