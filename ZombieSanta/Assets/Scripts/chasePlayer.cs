using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour {

	//adds target for the enemy
	public Transform target;
	//adds the aggro range for the enemy
	public float chaseRange;
	//speed of the enemy
	public float speed;
	public bool aggro = false;
	public float health;

	private bool movingLeft = true;

	protected Vector2 prevPos;

	protected GameObject manager;

	protected virtual void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("dolan");
		Debug.Log("trigger entered." + other.tag);
		if (other.gameObject.tag == "Player") {
			aggro = true;
			GetComponent<Animator>().SetBool("moving", true);
		}
	}

	public void ApplyDamage(int dmg) {
		health -= dmg;
        aggro = true;
        GetComponent<Animator>().SetBool("moving", true);
    }

	protected virtual void Start () {       
		//GameObject.FindGameObjectWithTag("GameManager");
	}

	public void Init(GameObject m, GameObject p) {
		manager = m;
		target = p.transform;
	}

	protected void MoveEnemy() {
		if (aggro == true && target != null) {
			prevPos = gameObject.transform.position;
			gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, target.position, speed * Time.deltaTime);
		}
	}

	private void FlipSprite() {
		//GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        
        Vector2 temp = transform.localScale;
        temp.x = temp.x * -1;
        transform.localScale = temp;
        
	}

	protected void CheckAndFlip() {
		if(prevPos.x < transform.position.x && movingLeft) {
			movingLeft = !movingLeft;
			FlipSprite();
		}
		else if(prevPos.x >= transform.position.x && !movingLeft) {
			movingLeft = !movingLeft;
			FlipSprite();
		}
	}

	// Update is called once per frame
	protected virtual void Update () {
		//Gets the distance from enemy to player, if its close it will chase
		MoveEnemy();
		CheckAndFlip();

		if(health <= 0) {
			// Spawn items
			manager.GetComponent<Spawner>().SpawnPickup(transform.position);
			manager.GetComponent<GameManager>().enemyCount--;
            manager.GetComponent<Spawner>().explode(transform.position);
			Destroy(gameObject);
		}

	}

}
