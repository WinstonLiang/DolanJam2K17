using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossScript : MonoBehaviour {
    public Transform target;
    public GameObject manager;
    public float flyTime;
    public GameObject spawns;
    private GameObject player;
    private float x;
    private float y;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        flyTime += Random.Range(-0.15f,0.15f);
        x = target.position.x - gameObject.transform.position.x + Random.Range(-1,1);
        y = target.position.y - gameObject.transform.position.y + 12 + Random.Range(-1,1);
        if (x >= 20)
            x = 20;
        if (x <= -20)
            x = -20;
        if (y >= 15)
            y = 15;
        if (y <= 0)
            y = 0;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(
            (x) * 0.5f,
            y),ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(new Vector3(0, 0, 180 * Time.deltaTime));
        flyTime -= Time.deltaTime;
        if (flyTime <= 0)
        {
            GameObject enemy = Instantiate(spawns, gameObject.transform.position, Quaternion.identity) as GameObject;
            enemy.GetComponent<chasePlayer>().Init(GameObject.FindGameObjectWithTag("GameManager"),
                player);
            Destroy(gameObject);
        }
	}
}
