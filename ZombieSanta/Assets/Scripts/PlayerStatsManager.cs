using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour {
	public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ApplyDamage(int dmg) {
		health -= dmg;
		StartCoroutine("TriggerInvisibility");
	}

	IEnumerator TriggerInvisibility() {
		GetComponent<BoxCollider2D>().enabled = false;
		for(int i = 1; i < 4; i++) {
			Color color1 = gameObject.GetComponent<SpriteRenderer>().color; 
			color1.a = .5f;
			gameObject.GetComponent<SpriteRenderer>().color = color1;
			yield return new WaitForSeconds(.1f*i);

			Color color2 = gameObject.GetComponent<SpriteRenderer>().color; 
			color2.a = 1f;
			gameObject.GetComponent<SpriteRenderer>().color = color2;
			yield return new WaitForSeconds(.1f*i);
		}
		GetComponent<BoxCollider2D>().enabled = true;
	}
}
