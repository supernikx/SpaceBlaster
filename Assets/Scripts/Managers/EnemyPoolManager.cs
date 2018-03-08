using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour {

    Vector3 enemyPoolPosition = new Vector3(1001, 1001, 1001);
    public EnemyController enemtPrefab;
    public int maxBullets = 20;
    List<EnemyController> enemy = new List<EnemyController>();

    private void Start()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            EnemyController enemyToAdd = Instantiate(enemtPrefab, transform);
            enemyToAdd.OnSpawn += OnEnemySpawn;
            enemyToAdd.OnDestroy += OnEnemyDestroy;
            OnEnemyDestroy(enemyToAdd);
            enemy.Add(enemyToAdd);
        }
    }

    private void OnEnemyDestroy(EnemyController bullet)
    {
        bullet.transform.position = enemyPoolPosition;
    }

    private void OnEnemySpawn(EnemyController bullet)
    {

    }

    public EnemyController GetEnemy()
    {
        foreach (EnemyController _enemy in enemy)
        {
            if (_enemy.currentState == EnemyController.State.InPool)
                return _enemy;
        }
        Debug.Log("Nessun enemy disponibile");
        return null;
    }

    private void OnDisable()
    {
        foreach (EnemyController _enemy in enemy)
        {
            _enemy.OnSpawn -= OnEnemySpawn;
            _enemy.OnDestroy -= OnEnemyDestroy;
        }
    }
}
