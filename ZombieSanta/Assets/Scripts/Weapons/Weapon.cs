using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour {

	public GameObject bulletObj;
	public int speed;
	public int charges;
	public int chargeIncrement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncrementCharge() {
		charges += chargeIncrement;
	}

	public int GetBulletCount() {
		return charges;
	}

	public virtual void Attack(Vector3 playerPos) {
		Debug.Log("Default attack");
		if(charges > 0) {
			Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerPos;
	        dir.Normalize();
	        GameObject bullet = Instantiate(bulletObj, playerPos, Quaternion.identity) as GameObject;
	        bullet.GetComponent<Rigidbody2D>().velocity = dir * speed;
	        charges--;
	    }
	}

	public virtual void StopAttack() {
		Debug.Log("Default Stop Attack");
	}

}
