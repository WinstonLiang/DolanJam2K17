using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour {

	//adds target for the enemy
	public Transform target;
	//adds the aggro range for the enemy
	public float chaseRange;
	//speed of the enemy
	public float speed;
	bool aggro = false;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("dolan");
		if (other.gameObject.tag == "Player") {
			aggro = true;
		}
	}

	void Start () {

	}
	// Update is called once per frame
	void Update () {
		//Gets the distance from enemy to player, if its close it will chase
		if (aggro == true) {
			gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, target.position, 1f * Time.deltaTime);
		}

	}

}
