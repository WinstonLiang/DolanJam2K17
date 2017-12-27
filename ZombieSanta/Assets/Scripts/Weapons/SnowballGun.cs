using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballGun : Weapon {

	private bool attacking;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}

	IEnumerator Attacking() {
   		while(attacking && charges > 0) {
   			base.Attack();
	        yield return new WaitForSeconds(.8f);
   		}
	}

	// Candy cane attack
	public override void Attack() {
		attacking = true;
		StartCoroutine("Attacking");
	}

	public override void StopAttack() {
		attacking = false;
	}
}
