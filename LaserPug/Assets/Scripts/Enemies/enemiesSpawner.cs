using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpawner : MonoBehaviour
{

    public GameObject CroquetteMeatGO;//this is our enemy prefab

    float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	void Start ()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //increase spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //function to spawn an enemy prefab positioned on the top edge of the screen and randomly between the left and right edge of the screen
    void SpawnEnemy()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //instantiate an enemy
        GameObject anEnemy = (GameObject)Instantiate(CroquetteMeatGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //schedule when to spawn the next enemy
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if(maxSpawnRateInSeconds > 1f)
        {
            //pick a number between 1 and maxSpawnRateInSeconds
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;
        }

        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    //function to increse the dificulty of the game
    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }

        if(maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
}
