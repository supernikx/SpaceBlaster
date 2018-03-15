using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerScore))]
public class ShootInput : MonoBehaviour {
    [Header("Shoot Settings")]
    public KeyCode shootInput = KeyCode.Space;
    public BulletBase bullet;
    public float force;
    public ShootTypes type;
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
        BulletStandard bulletToShoot = pool.GetPooledObject(bullet.objectID, gameObject).GetComponent<BulletStandard>();
        bulletToShoot.transform.position = shootPosition.position;
        bulletToShoot.OnObjectDestroy += OnBulletDestroy;
        bulletToShoot.OnEnemyKill += OnEnemyKilled;
        bulletToShoot.Shoot(transform.forward, force, type);
    }

    private void OnEnemyKilled(EnemyController enemyKilled, BulletBase bullet)
    {
        scoreController.Score += enemyKilled.enemyType.score;
        bullet.OnEnemyKill -= OnEnemyKilled;
    }

    private void OnBulletDestroy(IPoolManager _gameObject)
    {
        _gameObject.OnObjectDestroy -= OnBulletDestroy;
        ((BulletStandard)_gameObject).OnEnemyKill -= OnEnemyKilled;
    }
}
