using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Milk : ProjectileAttack {

	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}

	protected override void OnCollisionEnter2D(Collision2D other) {
		// do nothing
	}
}
