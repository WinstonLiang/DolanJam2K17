using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballGun : Weapon {

	private bool attacking;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator Attacking() {
   		while(attacking && charges > 0) {
   			base.Attack(player.transform.position);
	        yield return new WaitForSeconds(.8f);
   		}
	}

	// Candy cane attack
	public override void Attack(Vector3 playerPos) {
		attacking = true;
		StartCoroutine("Attacking");
	}

	public override void StopAttack() {
		attacking = false;
	}
}
