using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour {

	/*
	public Transform camTransform;

	public float shakeDuration = 0f;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	Vector3 originalPos;
	*/
	public float shakeTimer;
	public float shakeAmount;

	/*
	void Awake() {
		
		if (camTransform == null) {
			camTransform = GetComponent (typeof(Transform)) as Transform;
		}

	}

	void OneEnable() {
		
		originalPos = camTransform.localPosition;

	}

	// Update is called once per frame
	void Update () {

		if (shakeDuration > 0) {
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
	*/

	void Update() {
		if (shakeTimer >= 0) {
			Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3 (transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
			shakeTimer -= Time.deltaTime;
		}
		if (Input.GetKey("g")) {
			ShakeCamera (0.3f, 0.5f);
		}
	}

	public void ShakeCamera(float shakePower, float shakeDur) {
		shakeAmount = shakePower;
		shakeTimer = shakeDur;
	}
}