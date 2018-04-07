using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : ShootInput, IWeapon
{
    public void Shoot(Transform shootPosition)
    {
        BulletBase bulletToShoot = pool.GetPooledObject(ObjectTypes.BulletStandard, gameObject).GetComponent<BulletBase>();
        bulletToShoot.transform.position = shootPosition.position;
        bulletToShoot.OnObjectDestroy += OnBulletDestroy;
        bulletToShoot.OnEnemyKill += OnEnemyKilled;
        bulletToShoot.OnEnemyHit += OnEnemyHit;
        bulletToShoot.Shoot(shootPosition.forward);
    }
}
