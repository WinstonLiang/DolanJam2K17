using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject[] pickups;
	public GameObject[] enemies;
	public int[] enemyCounts;
	public GameObject mapBounds;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnEnemies() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		for(int i = 0; i < enemies.Length; i++) {
			for(int j = 0; j < enemyCounts[i]; j++) {
				GameObject enemyClone = Instantiate(enemies[i], GetSpawnPos(), Quaternion.identity) as GameObject;
				enemyClone.GetComponent<chasePlayer>().Init(gameObject, player);
				GetComponent<GameManager>().enemyCount++;
			}
		}
	}

	Vector2 GetSpawnPos() {
		Bounds b = mapBounds.GetComponent<PolygonCollider2D>().bounds;
		Vector2 spawnPos = new Vector2(Random.Range(b.min.y, b.max.y), Random.Range(b.min.y, b.max.y));
		while(!mapBounds.GetComponent<PolygonCollider2D>().OverlapPoint(spawnPos) || mapBounds.GetComponent<CircleCollider2D>().OverlapPoint(spawnPos)) {
			spawnPos = new Vector2(Random.Range(b.min.y, b.max.y), Random.Range(b.min.y, b.max.y));
		}
		Debug.Log(spawnPos);
		return spawnPos;
	}

	public void SpawnPickup(Vector3 pos) {
		int randNum = Random.Range(0, 100);
		GameObject toSpawn;
        if (randNum <= 50)
        {
            if (randNum <= 5)
            {
                toSpawn = pickups[0];
            }
            else if (randNum > 5 && randNum <= 15)
            {
                toSpawn = pickups[1];
            }
            else if (randNum > 15 && randNum <= 25)
            {
                toSpawn = pickups[2];
            }
            else
            {
                toSpawn = pickups[3];
            }
            Instantiate(toSpawn, pos, Quaternion.identity);
        }
	}
}
