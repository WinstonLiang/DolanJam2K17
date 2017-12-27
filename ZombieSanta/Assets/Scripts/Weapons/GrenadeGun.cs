using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGun : Weapon {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected override void Update () {	
	}

	public override void Attack() {
		if(charges > 0) {
	        Instantiate(bulletObj, transform.position, Quaternion.identity);
	        charges--;
	    }
	}
}
