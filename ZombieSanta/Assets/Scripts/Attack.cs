using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	public int dmg;
	public string target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}

	protected virtual void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == target) {
			other.gameObject.SendMessage("ApplyDamage", dmg);
		}
	}
}
