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
	public int health;

	private bool movingLeft = true;

	private Vector2 prevPos;

	protected GameObject manager;

	protected virtual void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("dolan");
		if (other.gameObject.tag == "Player") {
			aggro = true;
			GetComponent<Animator>().SetBool("moving", true);
		}
	}

	void ApplyDamage(int dmg) {
		health -= dmg;
	}

	void Start () {
		//GameObject.FindGameObjectWithTag("GameManager");
	}

	public void Init(GameObject m, GameObject p) {
		manager = m;
		target = p.transform;
	}

	// Update is called once per frame
	protected virtual void Update () {
		//Gets the distance from enemy to player, if its close it will chase
		if (aggro == true && target != null) {
			prevPos = gameObject.transform.position;
			gameObject.transform.position = Vector2.MoveTowards (gameObject.transform.position, target.position, speed * Time.deltaTime);
		}
		if(prevPos.x < transform.position.x && movingLeft) {
			movingLeft = !movingLeft;
			GetComponent<SpriteRenderer>().flipX = true;
		}
		else if(prevPos.x >= transform.position.x && !movingLeft) {
			movingLeft = !movingLeft;
			GetComponent<SpriteRenderer>().flipX = false;
		}

		if(health <= 0) {
			// Spawn items
			manager.GetComponent<Spawner>().SpawnPickup(transform.position);
			manager.GetComponent<GameManager>().enemyCount--;
			Destroy(gameObject);
		}

	}

	void OnParticleCollision(GameObject other){
		Debug.Log("on enemy: " + other.tag);
		//if(other.tag == "Enemy") {
		Debug.Log("a;lsdkjfal;skdfj");
		Vector2 direction = other.transform.position - transform.position;
		direction.Normalize();
	    GetComponent<Rigidbody2D>().velocity = direction * .2f;
		//}
	}

}
