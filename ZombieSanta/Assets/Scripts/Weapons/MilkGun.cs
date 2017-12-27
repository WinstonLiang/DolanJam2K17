using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkGun : Weapon {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Attack(Vector3 playerPos) {
		if(charges > 0) {
			Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerPos;
        	dir.Normalize();
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	        GameObject bullet = Instantiate(bulletObj, playerPos, Quaternion.identity) as GameObject;
	        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
	        charges--;
	    }
	}
}