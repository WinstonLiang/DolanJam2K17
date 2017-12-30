using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SANTACHASE : chasePlayer {

    public float pauseTime;
    public float stompTime;
    public Sprite[] santaSprites;
    public GameObject[] minions;
    public GameObject childCollider;
    private float stompTrack;
    private float pauseTrack;
    private bool stomping;
    private bool spriteSwitch = false;
    private bool thrown = false;
    private bool colliderS = false;
    public Image healthBar;
    private float maxHealth;

    protected override void Start()
    {
        maxHealth = health;
        healthBar = GameObject.FindGameObjectWithTag("BossBar").GetComponent<Image>();
    }

    // Update is called once per frame
    protected override void Update () {
        healthBar.fillAmount = health / maxHealth;
        if (stomping)
        {
            if (!spriteSwitch)
            {
                spriteSwitch = true;
                GetComponent<Animator>().SetBool("SantaSwitch", !GetComponent<Animator>().GetBool("SantaSwitch"));

                if (colliderS)
                {
                    gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                    childCollider.GetComponent<PolygonCollider2D>().enabled = false;
                    colliderS = false;
                }
                else
                {
                    gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                    childCollider.GetComponent<PolygonCollider2D>().enabled = true;
                    colliderS = true;
                }

            }

            if (!thrown)
            {
                Vector2 throwFrom = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2);
                for(int i = 0; i < Random.Range(1,3); i++)
                {
                    Instantiate(minions[Random.Range(0, minions.Length - 1)],throwFrom,Quaternion.identity);
                }
                thrown = true;
            }
            prevPos = transform.position;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.position, speed * Time.deltaTime);
            CheckAndFlip();
            stompTrack -= Time.deltaTime;
            if(stompTrack <= 0)
            {
                thrown = false;
                stomping = false;
                spriteSwitch = false;
                //GetComponent<Animator>().SetBool("SantaSwitch", !GetComponent<Animator>().GetBool("SantaSwitch"));
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

        if(health <= 0) {
            // Spawn items
            manager.GetComponent<Spawner>().explode(transform.position);
            manager.GetComponent<GameManager>().TriggerBossWin();
            Destroy(gameObject);
        }
	}
}
