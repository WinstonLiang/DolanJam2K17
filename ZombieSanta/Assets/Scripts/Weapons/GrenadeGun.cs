﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGun : Weapon {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected override void Update () {	
	}

	/*public override void Attack() {
		/*if(charges > 0 && Time.time - lastAttack >= cooldown) {
			Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        	dir.Normalize();
        	Vector2 targetPos = dir + new Vector2(transform.position.x, transform.position.y);
	        GameObject bullet = Instantiate(bulletObj, targetPos, Quaternion.identity) as GameObject;
	        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
	        bullet.GetComponent<Rigidbody2D>().velocity = dir * speed;
	        lastAttack = Time.time;
	        charges--;
	    }
	}*/
}
