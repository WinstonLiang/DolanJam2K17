using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeAttack : ProjectileAttack {

	private Vector2 delta = new Vector2(.1f, .1f);
	
	// Update is called once per frame
	protected override void Update () {
		if(GetComponent<Rigidbody2D>().velocity.x < delta.x && GetComponent<Rigidbody2D>().velocity.y < delta.y) {
			GetComponent<CircleCollider2D>().enabled = true;
			Destroy(gameObject, .2f);
		}		
	}

	protected override void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == target) {
			GetComponent<CircleCollider2D>().enabled = true;
			Destroy(gameObject, .2f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == target) {
			other.gameObject.SendMessage("ApplyDamage", dmg);
			GetComponent<CircleCollider2D>().enabled = true;
			Destroy(gameObject, .2f);			
		}
	}
}
