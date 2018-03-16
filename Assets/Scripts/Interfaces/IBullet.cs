﻿using UnityEngine;

public class IBulletEvents
{
    public delegate void BulletKillEvent(EnemyBase enemyKilled, BulletBase bullet);
}


public interface IBullet
{
    ObjectTypes objectID { get; }
    void Shoot(Vector3 _direction);
    void DestroyMe();
    void DestroyVisualEffect();
    IBulletEvents.BulletKillEvent OnEnemyKill { get; set; }

}
