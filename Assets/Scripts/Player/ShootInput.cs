using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerScore))]
public class ShootInput : MonoBehaviour {
    [Header("Shoot Settings")]
    public KeyCode shootInput = KeyCode.Space;
    public Transform shootPosition;
    public List<IWeapon> inventroy = new List<IWeapon>(4);
    public int activeSlot;
    protected PoolManager pool;
    protected PlayerScore scoreController;

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
            inventroy[activeSlot].Shoot(shootPosition);
        }
	}

    protected void OnEnemyHit(EnemyBase enemyKilled, BulletBase bullet)
    {
        bullet.OnEnemyHit -= OnEnemyHit;
    }

    protected void OnEnemyKilled(EnemyBase enemyKilled, BulletBase bullet)
    {
        scoreController.Score += enemyKilled.Stats.score;
        bullet.OnEnemyKill -= OnEnemyKilled;
    }

    protected void OnBulletDestroy(IPoolManager _gameObject)
    {
        _gameObject.OnObjectDestroy -= OnBulletDestroy;
        ((BulletBase)_gameObject).OnEnemyHit -= OnEnemyHit;
        ((BulletBase)_gameObject).OnEnemyKill -= OnEnemyKilled;
    }
}
