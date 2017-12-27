using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkGun : Weapon {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}

	public override void Attack() {
		if(charges > 0) {
			Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        	dir.Normalize();
	        GameObject bullet = Instantiate(bulletObj, transform.position, Quaternion.identity) as GameObject;
	        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
	        charges--;
	    }
	}
}