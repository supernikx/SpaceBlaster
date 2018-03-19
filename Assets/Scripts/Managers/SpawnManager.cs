using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    PoolManager pool;
    public float spawnTime;
    float spawnTimer, screenHeight, screenWidth;
    public List<EnemyBase> enemyTypes = new List<EnemyBase>();

	void Start () {
        pool = PoolManager.instance;
        screenHeight = Camera.main.orthographicSize+Camera.main.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTime)
        {
            EnemyBase enemyPooled = pool.GetPooledObject(enemyTypes[Random.Range(0, enemyTypes.Count)].objectID,gameObject).GetComponent<EnemyBase>();
            screenWidth = Camera.main.orthographicSize * Camera.main.aspect - enemyPooled.transform.localScale.magnitude;
            enemyPooled.Spawn(new Vector3(Random.Range(screenWidth, -screenWidth), transform.position.y, screenHeight));
            spawnTimer = 0f;
        }
	}
}
