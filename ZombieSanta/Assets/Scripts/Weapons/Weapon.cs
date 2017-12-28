using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour {

	public GameObject bulletObj;
	public int speed;
	public int charges;
	public int chargeIncrement;
	public float cooldown = 5f;
	protected float lastAttack;

	// Use this for initialization
	void Start () {
	}

	public float getTimeLeft() {
		return Time.time - lastAttack >= cooldown ? 0f : Time.time - lastAttack;
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
		if(charges > 0 && Time.time - lastAttack >= cooldown) {
			Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        	dir.Normalize();
        	Vector2 targetPos = dir + new Vector2(transform.position.x, transform.position.y);
	        GameObject bullet = Instantiate(bulletObj, targetPos, Quaternion.identity) as GameObject;
	        bullet.GetComponent<Rigidbody2D>().velocity = dir * speed;
	        lastAttack = Time.time;
	        charges--;
	    }
	}

	public virtual void StopAttack() {
		Debug.Log("Default Stop Attack");
	}

}
