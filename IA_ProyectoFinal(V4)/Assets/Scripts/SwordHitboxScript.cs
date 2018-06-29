using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitboxScript : MonoBehaviour {

    ScoreScript score;
    SpawnerBehaviour spawner;

	void Start () {

        score = GameObject.Find("GameManager").GetComponent<ScoreScript>();
        spawner = GameObject.Find("EnemySpawner").GetComponent<SpawnerBehaviour>();
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            spawner.enemyCounter -= 1;
            score.actualScore += 10;
            Destroy(other.gameObject);
        }
    }
}
