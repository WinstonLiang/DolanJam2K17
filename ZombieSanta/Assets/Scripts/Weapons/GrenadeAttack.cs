using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeAttack : ProjectileAttack {

	private Vector2 delta = new Vector2(.1f, .1f);
	private bool destroyTriggered = false;
	
	// Update is called once per frame
	protected override void Update () {
		if(GetComponent<Rigidbody2D>().velocity.x < delta.x && GetComponent<Rigidbody2D>().velocity.y < delta.y && !destroyTriggered) {
			GetComponent<CircleCollider2D>().enabled = true;
			destroyTriggered = true;
			GetComponent<ParticleSystem>().Play();
			GetComponent<SpriteRenderer>().enabled = false;
			Destroy(gameObject, 1f);
		}		
	}

	protected override void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == target && !destroyTriggered) {
			destroyTriggered = true;
			GetComponent<CircleCollider2D>().enabled = true;
			GetComponent<ParticleSystem>().Play();
			GetComponent<SpriteRenderer>().enabled = false;
			Destroy(gameObject, 1f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == target) {
			other.gameObject.SendMessage("ApplyDamage", dmg);
			if(!destroyTriggered) {
				destroyTriggered = true;
				GetComponent<CircleCollider2D>().enabled = true;
				GetComponent<SpriteRenderer>().enabled = false;
				GetComponent<ParticleSystem>().Play();
				Destroy(gameObject, 1f);
			}
		}
	}
}
