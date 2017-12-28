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
		if(attacking && Time.time - lastAttack >= cooldown) {
			base.Attack();
		}
	}

	// Candy cane attack
	public override void Attack() {
		attacking = true;
	}

	public override void StopAttack() {
		attacking = false;
	}
}
