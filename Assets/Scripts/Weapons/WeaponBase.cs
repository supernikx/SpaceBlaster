using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    protected PlayerScore scoreController;
    protected PoolManager pool;

    private void Start()
    {
        scoreController = GetComponent<PlayerScore>();
        pool = PoolManager.instance;
    }
    public abstract void Shoot(Transform shootPosition, GameObject callingobject);


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
