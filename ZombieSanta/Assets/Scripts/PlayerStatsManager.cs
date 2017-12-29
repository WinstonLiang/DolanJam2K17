using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatsManager : MonoBehaviour {
	public float health;
	public Image healthbar;
	private GameObject gameManager;
	private float maxHealth;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		GameObject ui = GameObject.FindGameObjectWithTag("PlayerUI");
		foreach(Transform child in ui.transform) {
			if(child.tag == "Health") {
				healthbar = child.GetChild(0).gameObject.GetComponent<Image>();
			}
		}
		maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		healthbar.fillAmount = health/maxHealth;
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
		Physics2D.IgnoreLayerCollision(11, 12, true);
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
		Physics2D.IgnoreLayerCollision(11, 12, false);
	}
}
