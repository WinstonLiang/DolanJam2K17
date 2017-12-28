using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProjectileAttack : Attack {

	public float ttl = 4f;
	private float start = 0f;

	// Use this for initialization
	protected virtual void Start () {
		start = Time.time;
	}
	
	// Update is called once per frame
	protected override void Update () {
		if(Time.time - start >= ttl) {
			Destroy(gameObject);
		}	
	}

	protected override void OnCollisionEnter2D(Collision2D other) {
		base.OnCollisionEnter2D(other);
		if(other.gameObject.tag == target) {
			Destroy(gameObject);
		}
	}
}
