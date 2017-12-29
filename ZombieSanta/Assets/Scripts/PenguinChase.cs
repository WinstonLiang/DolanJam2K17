using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinChase : chasePlayer {

	public float slideCD;
	public float slideLength;
	public int slideSpeed;
	private float startSlide = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	IEnumerator Slide() {
		GetComponent<Animator>().SetBool("sliding", true);
		float prevDrag = GetComponent<Rigidbody2D>().drag;
		GetComponent<Rigidbody2D>().drag = 1f;
		Vector2 dir = target.position - transform.position;
    	dir.Normalize();
        GetComponent<Rigidbody2D>().velocity = dir * slideSpeed;
        yield return new WaitForSeconds(slideLength);
   		GetComponent<Animator>().SetBool("sliding", false);
		GetComponent<Rigidbody2D>().drag = prevDrag;
        aggro = true;
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update();
		if(aggro && Time.time - startSlide >= slideCD) {
			// start slide
			aggro = false;
			StartCoroutine("Slide");
			startSlide = Time.time;
		}
	}
}
