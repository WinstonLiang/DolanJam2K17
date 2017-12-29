using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatsManager : MonoBehaviour {
	public int health;
	private GameObject gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ApplyDamage(int dmg) {
		health -= dmg;
		StartCoroutine("TriggerInvisibility");

		//game over
		if (health <= 0){
            Destroy(gameObject);
			gameManager.GetComponent<GameManager> ().SwitchScene (2);
		}
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
