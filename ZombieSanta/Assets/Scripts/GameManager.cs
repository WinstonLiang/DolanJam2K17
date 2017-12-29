using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private enum FadeDirection {In, Out};
	public int enemyCount;
	public Image fadeOutImage;
	public float fadeSpeed;
	private Text countText;
	private GameObject tracker;

	// Use this for initialization
	void Start () {
		fadeOutImage = GameObject.FindGameObjectWithTag("FadeOutImage").GetComponent<Image>();
		StartCoroutine(Fade(FadeDirection.Out));
		//InitLvl1();
	}

	void Awake() {
		tracker = GameObject.FindGameObjectWithTag("Tracker");
		if(!tracker.GetComponent<Tracker>().unlocked && SceneManager.GetActiveScene().buildIndex == 0) {
			GameObject.FindGameObjectWithTag("Toggler").SetActive(false);
		}
		else if(tracker.GetComponent<Tracker>().unlocked && SceneManager.GetActiveScene().buildIndex == 0) {
			GameObject.FindGameObjectWithTag("pg").GetComponent<Image>().enabled = false;
		}
		if(SceneManager.GetActiveScene().buildIndex == 1) { // If lvl 1:
			InitLvl1();
		}
		if(SceneManager.GetActiveScene().buildIndex == 4) {
			InitLvl2();
		}
		if(SceneManager.GetActiveScene().buildIndex == 5) {
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if(player != null) {
				Destroy(player);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().buildIndex == 1) { // If lvl 1:
			if(enemyCount == 0) {
				SwitchScene(4);
			}
			countText.text = "Enemies: " + enemyCount.ToString();
		}
	}

	public void SetEnabledFilter(GameObject cry) {
		cry.GetComponent<Image>().enabled = true;
	}

	public void SetDisabledFilter(GameObject cry) {
		cry.GetComponent<Image>().enabled = false;
	}

	public void SetToggled(bool t) {
		tracker.GetComponent<Tracker>().SetToggled(t);
	}

	private void InitLvl1() {
		//Debug.Log("cry");
		GetComponent<Spawner>().SpawnEnemies();
		countText = GameObject.FindGameObjectWithTag("EnemyCount").GetComponent<Text>();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(!tracker.GetComponent<Tracker>().toggled) {
	        player.GetComponent<PlayerController>().SetAnimator("pg");
        }
        else {
	        player.GetComponent<PlayerController>().SetAnimator("h");        	
        }

	}

	private void InitLvl2() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().Init(new Vector2(-7.6f, 10.35f));
        if(!tracker.GetComponent<Tracker>().toggled) {
	        player.GetComponent<PlayerController>().SetAnimator("pg");
        }
        else {
	        player.GetComponent<PlayerController>().SetAnimator("h");        	
        }
        GetComponent<Spawner>().SpawnSanta();
		countText = GameObject.FindGameObjectWithTag("EnemyCount").GetComponent<Text>();
		countText.enabled = false;
	}

	public void TriggerBossWin() {
		tracker.GetComponent<Tracker>().unlocked = true;
		SwitchScene(5);
	}

	public void SwitchScene(int lvl) {
		StartCoroutine(FadeAndLoad(FadeDirection.In, lvl));
	}

	private IEnumerator Fade(FadeDirection dir) {
		float alpha = (FadeDirection.Out == dir) ? 1 : 0;
		float fadeEndValue = (dir == FadeDirection.Out)? 0 : 1;
		if (dir == FadeDirection.Out) {
			while (alpha >= fadeEndValue) {
				SetColorImage (ref alpha, dir);
				yield return null;
			}
			fadeOutImage.enabled = false; 
		}
		else {
			fadeOutImage.enabled = true; 
			while (alpha <= fadeEndValue) {
				SetColorImage (ref alpha, dir);
				yield return null;
			}
		}

	}

	private IEnumerator FadeAndLoad(FadeDirection dir, int lvl) {
		float alpha = (FadeDirection.Out == dir) ? 1 : 0;
		float fadeEndValue = (dir == FadeDirection.Out)? 0 : 1;
		if (dir == FadeDirection.Out) {
			while (alpha >= fadeEndValue) {
				SetColorImage (ref alpha, dir);
				yield return null;
			}
			fadeOutImage.enabled = false; 
		}
		else {
			fadeOutImage.enabled = true; 
			while (alpha <= fadeEndValue) {
				SetColorImage (ref alpha, dir);
				yield return null;
			}
		}
		SceneManager.LoadScene(lvl);
	}

	private void SetColorImage(ref float alpha, FadeDirection fadeDirection) {
		fadeOutImage.color = new Color (fadeOutImage.color.r,fadeOutImage.color.g, fadeOutImage.color.b, alpha);
		alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out)? -1 : 1) ;
	}
}
