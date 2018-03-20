using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerScore))]
public class ShootInput : MonoBehaviour {
    [Header("Shoot Settings")]
    public KeyCode shootInput = KeyCode.Space;
    public BulletBase BulletTypePrefab;
    public Transform shootPosition;
    PoolManager pool;
    PlayerScore scoreController;

    private void Awake()
    {

    }

    private void Start()
    {
        pool = PoolManager.instance;
        scoreController = GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(shootInput))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        BulletBase bulletToShoot = pool.GetPooledObject(BulletTypePrefab.objectID, gameObject).GetComponent<BulletBase>();
        bulletToShoot.transform.position = shootPosition.position;
        bulletToShoot.OnObjectDestroy += OnBulletDestroy;
        bulletToShoot.OnEnemyKill += OnEnemyKilled;
        bulletToShoot.Shoot(shootPosition.forward);
    }

    private void OnEnemyKilled(EnemyBase enemyKilled, BulletBase bullet)
    {
        scoreController.Score += enemyKilled.Stats.score;
        bullet.OnEnemyKill -= OnEnemyKilled;
    }

    private void OnBulletDestroy(IPoolManager _gameObject)
    {
        _gameObject.OnObjectDestroy -= OnBulletDestroy;
        ((BulletBase)_gameObject).OnEnemyKill -= OnEnemyKilled;
    }
}
