using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject weapon;

	private bool facingLeft;	

	// Use this for initialization
	void Start () {
		facingLeft = true;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Attack();
	}

	private void Flip() {
		Vector3 facingPos =  transform.localScale;
		facingPos.x *= -1;
		facingLeft = !facingLeft;
		transform.localScale = facingPos;
	}

	private void Move() {
		float xMovement = Input.GetAxis("Horizontal") * speed;
		float yMovement = Input.GetAxis("Vertical") * speed;
		GetComponent<Rigidbody2D>().velocity = new Vector2(xMovement, yMovement);

		// Flip sprite if the player goes the opposite direction from before
		if(xMovement > 0 && facingLeft || xMovement < 0 && !facingLeft) {
			Flip();
		}
	}

	private void Attack() {
		if(Input.GetMouseButtonDown(0)) {
			Debug.Log("Player attacked");
		}
	}
}
