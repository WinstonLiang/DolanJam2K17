using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject[] weapons;
	public Image[] weaponIcons;

	private int selectedWeapon;
	private bool facingLeft;	

	// Use this for initialization
	void Start () {
		facingLeft = true;
		selectedWeapon = 0;
		for(int i = 1; i < weaponIcons.Length; i++) {
			Color color1 = weaponIcons[i].color;
			color1.a = .5f;
			weaponIcons[i].color = color1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		UpdateWeaponSelection();
		UpdateBulletCounters();
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

	private void UpdateWeaponSelection() {
		string inputString = Input.inputString;
		if(inputString != "") {
			int prevWeapon = selectedWeapon;
			switch(inputString) {
				case "1":
					selectedWeapon = 0;
					break;
				case "2":
					selectedWeapon = 1;
					break;
				case "3":
					selectedWeapon = 2;
					break;
			}
			if(prevWeapon != selectedWeapon) {
				Color color1 = weaponIcons[prevWeapon].color;
				color1.a = .5f;
				Color color2 = weaponIcons[selectedWeapon].color;
				color2.a = 1f;
				weaponIcons[prevWeapon].color = color1;
				weaponIcons[selectedWeapon].color = color2;
			}
		}
	}

	private void UpdateBulletCounters() {
		for(int i = 0; i < weaponIcons.Length; i++) {
			weaponIcons[i].gameObject.transform.GetChild(0).GetComponent<Text>().text = weapons[i].GetComponent<Weapon>().GetBulletCount().ToString();
		}
	}

	private void Attack() {
		if(Input.GetMouseButtonDown(0)) {
			weapons[selectedWeapon].GetComponent<Weapon>().Attack(transform.position);
		}
		if(Input.GetMouseButtonUp(0)) {
			weapons[selectedWeapon].GetComponent<Weapon>().StopAttack();
		}

	}


	void OnTriggerEnter2D(Collider2D col){
		foreach (Transform weapon in transform){
			if (col.transform.tag == weapon.tag) {
				weapon.gameObject.GetComponent<Weapon> ().IncrementCharge (); 
				Destroy (col.transform.gameObject);
			}

		}

	}
}
			