using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    EnemyPoolManager poolManager;
    public float spawnTime;
    float spawnTimer, screenHeight, screenWidth;
    public List<EnemyTypes> enemyTypes = new List<EnemyTypes>();

	void Start () {
        poolManager = FindObjectOfType<EnemyPoolManager>();
        screenHeight = Camera.main.orthographicSize*2;
    }
	
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTime)
        {
            EnemyController enemyToSpawn;
            enemyToSpawn = poolManager.GetEnemy();
            screenWidth = Camera.main.orthographicSize * Camera.main.aspect - enemyToSpawn.transform.localScale.magnitude;
            Random.Range(screenWidth,-screenWidth);
            enemyToSpawn.Spawn(new Vector3(Random.Range(screenWidth, -screenWidth), transform.position.y, screenHeight), enemyTypes[Random.Range(0, enemyTypes.Count)]);
            spawnTimer = 0f;
        }
	}
}
