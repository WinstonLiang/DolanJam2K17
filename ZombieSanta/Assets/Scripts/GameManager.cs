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

	// Use this for initialization
	void Start () {
		fadeOutImage = GameObject.FindGameObjectWithTag("FadeOutImage").GetComponent<Image>();
		StartCoroutine(Fade(FadeDirection.Out));
		if(SceneManager.GetActiveScene().buildIndex == 1) { // If lvl 1:
			InitLvl1();
		}
		//InitLvl1();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void InitLvl1() {
		//Debug.Log("cry");
		GetComponent<Spawner>().SpawnEnemies();		
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
