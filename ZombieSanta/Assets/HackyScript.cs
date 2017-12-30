using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ApplyDamage(int dmg)
    {
        transform.parent.GetComponent<SANTACHASE>().ApplyDamage(dmg);
    }

    void OnCollisionEnter2D(Collision2D other) {
    	if(other.gameObject.tag == "Player") {
    		other.SendMessage("ApplyDamage", transform.parent.GetComponent<Attack>().dmg);
    	}
    }
}
