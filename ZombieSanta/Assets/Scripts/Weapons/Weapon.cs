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
	protected virtual void Update () {
		Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir.Normalize();
	    transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
	}

	public void IncrementCharge() {
		charges += chargeIncrement;
	}

	public int GetBulletCount() {
		return charges;
	}

	public virtual void Attack() {
		Debug.Log("Default attack");
		if(charges > 0) {
			Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
	        dir.Normalize();
	        GameObject bullet = Instantiate(bulletObj, transform.position, Quaternion.identity) as GameObject;
	        bullet.GetComponent<Rigidbody2D>().velocity = dir * speed;
	        charges--;
	    }
	}

	public virtual void StopAttack() {
		Debug.Log("Default Stop Attack");
	}

}
