using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour {

    public int chain;

	// Use this for initialization
	void Start() {
        chain = 0;
	}
	
	// Update is called once per frame
    
    void chainAggro(Collider2D other)
    {
        if (!gameObject.GetComponentInParent<chasePlayer>().aggro)
        {
            if (other.gameObject.tag == "Enemy")
            {
                if (other.gameObject.GetComponent<chasePlayer>() != null && other.gameObject.GetComponent<chasePlayer>().aggro
                    && other.gameObject.GetComponentInChildren<EnemyAggro>().chain < 1)
                {
                    transform.parent.gameObject.GetComponent<chasePlayer>().aggro = true;
                    transform.parent.gameObject.GetComponent<Animator>().SetBool("moving", true);
                    chain++;
                    transform.parent.gameObject.GetComponentInChildren<EnemyAggro>().chain++;
                }
            }
        }
    }

	void OnTriggerEnter2D(Collider2D other) {
        chainAggro(other);
	}

    void OnTriggerExit2D(Collider2D other)
    {
        chainAggro(other);
    }
}
