using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour {

    [SerializeField]
    private GameObject basicEnemy;

    float spawnCounter = 0;
    public float enemyCounter = 0;

    public int maxEnemiesOnScene = 2;

    void Start () {
		
	}
	
	void Update () {

        if (enemyCounter <= maxEnemiesOnScene)
        {
            spawnCounter += Time.deltaTime;

            if (spawnCounter >= 2.5f)
            {
                Spawn();
                spawnCounter = 0;
                enemyCounter++;

            }
        }
	}

    void Spawn()
    {
        Instantiate(basicEnemy, transform.position, Quaternion.identity);
    }
}
