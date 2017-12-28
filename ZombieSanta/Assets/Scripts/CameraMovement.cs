using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;		
	}
	
	void FixedUpdate () {
		if (target != null) {
			Vector3 point = GetComponent<Camera> ().WorldToViewportPoint (target.position);
			Vector3 delta = target.position - GetComponent<Camera> ().ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			// Damper on the movement
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
		}
	}
}
