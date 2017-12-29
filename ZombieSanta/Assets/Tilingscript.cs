using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilingscript : MonoBehaviour {

	public int width;
	public int height;
	public GameObject tilePrefab;
	public GameObject tree;
	public GameObject wallingTree;
	public float tileOffset = 1f;

	void Start() {
		GenerateMap ();
	}	

	void GenerateMap(){
		for (int x = -12; x < -12 + width*3; x+= 3) {
			for (int y = -9; y < -9 + height*3; y+= 3) {
				Vector2 position = new Vector2(x * tileOffset, y * tileOffset);
				Vector2 position2 = new Vector2 (x + 1.5f, y);
				Instantiate(tilePrefab, position, Quaternion.identity);
				if (x == -12 || x >= -12 + width*3 - 3)
					Instantiate (wallingTree, position, Quaternion.identity);
				if (y == -9 || y >= -9 + height*3 - 3) {
					Instantiate (tree, position, Quaternion.identity);
					Instantiate (tree, position2, Quaternion.identity);
				}
					

			}
		}
	}
}
