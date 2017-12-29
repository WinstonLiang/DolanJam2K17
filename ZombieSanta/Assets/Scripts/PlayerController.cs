using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject[] weapons;
	public Image[] weaponIcons;
    public Vector2 starting = new Vector2(-7.6f, -6.3f);

	private int selectedWeapon;
	private bool facingLeft;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectsWithTag("Player").Length == 1) {
			DontDestroyOnLoad(transform.gameObject);
		}
		else {
			Destroy(gameObject);
		}
        Init(starting);
	}

    public void Init(Vector2 startPos)
    {
        transform.position = startPos;
        weaponIcons = new Image[weapons.Length];
        GameObject playerUI = GameObject.FindGameObjectWithTag("PlayerUI");
        foreach (Transform child in playerUI.transform)
        {
            if (child.tag == "WeaponIcons")
            {
                foreach (Transform weapon in child)
                {
                    weaponIcons[GetWeaponIndex(weapon.tag)] = weapon.GetComponent<Image>();
                }
            }
        }
        facingLeft = false;
        selectedWeapon = 0;
        for (int i = 1; i < weapons.Length; i++)
        {
            weapons[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        for (int i = 1; i < weaponIcons.Length - 1; i++)
        {
            Color color1 = weaponIcons[i].color;
            color1.a = .5f;
            weaponIcons[i].color = color1;
        }

        GetComponent<PlayerStatsManager>().Init();
    }
	
	// Update is called once per frame
	void Update () {
		Move();
		UpdateWeaponSelection();
		UpdateBulletCountersAndCooldown();
		Attack();
	}

	private int GetWeaponIndex(string tag) {
		for(int i = 0; i < weapons.Length; i++) {
			if(weapons[i].tag == tag) {
				return i;
			}
		}
		return -1;
	}

	private void Flip() {
		Vector3 facingPos =  transform.localScale;
		facingPos.x *= -1;
		facingLeft = !facingLeft;
		transform.localScale = facingPos;
	}

	private void Move() {
		float xMovement = Input.GetAxis("Horizontal");
		float yMovement = Input.GetAxis("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2(xMovement * speed, yMovement * speed);
		if(Math.Abs(xMovement) < .3f && Math.Abs(yMovement) < .3f) {
			GetComponent<Animator>().SetBool("moving", false);
		}
		else {
			GetComponent<Animator>().SetBool("moving", true);
		}

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
				weapons[prevWeapon].GetComponent<SpriteRenderer>().enabled = false;
				weaponIcons[prevWeapon].color = color1;
				weapons[selectedWeapon].GetComponent<SpriteRenderer>().enabled = true;
				weaponIcons[selectedWeapon].color = color2;
			}
		}
	}

	private void UpdateBulletCountersAndCooldown() {
		for(int i = 0; i < weaponIcons.Length; i++) {
			foreach(Transform child in weaponIcons[i].gameObject.transform) {
				if(child.gameObject.tag == "CooldownImage") {
					float timeLeft = weapons[i].GetComponent<Weapon>().GetTimeLeft();
					if(timeLeft > 0 && i != 2) {
						child.GetComponent<Image>().fillAmount = 1 - weapons[i].GetComponent<Weapon>().GetTimeLeft();
					}
					else {
						child.GetComponent<Image>().fillAmount = 0;						
					}
				}
				else {
					child.GetComponent<Text>().text = weapons[i].GetComponent<Weapon>().GetBulletCount().ToString();
				}
			}
		}
	}

	private void Attack() {
		if(Input.GetMouseButtonDown(0)) {
			weapons[selectedWeapon].GetComponent<Weapon>().Attack();
		}
		if(Input.GetMouseButtonUp(0)) {
			weapons[selectedWeapon].GetComponent<Weapon>().StopAttack();
		}
		if(Input.GetKeyDown(KeyCode.X)) {
			weapons[3].GetComponent<Weapon>().Attack();
		}

	}

	void OnTriggerEnter2D(Collider2D col) {
		foreach (Transform weapon in transform) {
			if (col.transform.tag == weapon.tag) {
				weapon.gameObject.GetComponent<Weapon> ().IncrementCharge (); 
				Destroy (col.transform.gameObject);
			}

		}
	}
}
			