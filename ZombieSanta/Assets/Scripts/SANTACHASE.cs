using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SANTACHASE : MonoBehaviour {

    public Transform MAIWAIFU;
    public float speed;
    public float pauseTime;
    public float stompTime;
    public Sprite[] santaSprites;
    public GameObject[] minions;
    private float stompTrack;
    private float pauseTrack;
    private bool stomping;
    private bool spriteSwitch = false;
    private bool thrown = false;


	// Use this for initialization
	void Start () {
        MAIWAIFU = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (stomping)
        {
            if (!spriteSwitch)
            {
                spriteSwitch = true;
                if (gameObject.GetComponent<SpriteRenderer>().sprite == santaSprites[0])
                    gameObject.GetComponent<SpriteRenderer>().sprite = santaSprites[1];
                else
                    gameObject.GetComponent<SpriteRenderer>().sprite = santaSprites[0];
            }
            if (!thrown)
            {
                Vector2 throwFrom = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2);
                for(int i = 0; i < Random.Range(1,5); i++)
                {
                    Instantiate(minions[(int)Random.Range(0, minions.Length - 0.1f)],throwFrom,Quaternion.identity);
                }
                thrown = true;
            }
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, MAIWAIFU.position, speed * Time.deltaTime);
            stompTrack -= Time.deltaTime;
            if(stompTrack <= 0)
            {
                thrown = false;
                stomping = false;
                spriteSwitch = false;
                stompTrack = stompTime;
            }
        }
        else
        {
            pauseTrack -= Time.deltaTime;
            if(pauseTrack <= 0)
            {
                stomping = true;
                pauseTrack = pauseTime;
            }
        }
	}
}
