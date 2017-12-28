using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanEnemy : chasePlayer {

	public GameObject bulletObj;
	public int projSpeed;
	public int attackInterval;

	private float lastAttack;
	private bool attacking;

	// Use this for initialization
	void Awake () {
		attacking = false;
		lastAttack = Time.time;
	}

	protected override void OnTriggerEnter2D(Collider2D other) {
		base.OnTriggerEnter2D(other);

		if (other.gameObject.tag == "Player" && !attacking) {
			attacking = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			attacking = false;
		}
	}

	void AttackPlayer() {
		Vector2 dir = target.position - transform.position;
    	dir.Normalize();
    	Vector2 targetPos = dir + new Vector2(transform.position.x, transform.position.y);
        GameObject bullet = Instantiate(bulletObj, targetPos, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = dir * projSpeed;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		if (aggro && target != null && attacking && Time.time - lastAttack >= attackInterval) {
			AttackPlayer();
			lastAttack = Time.time;
		}
	}
}
