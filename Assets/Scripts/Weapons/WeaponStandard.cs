using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStandard : WeaponBase {

    public override void Shoot(Transform shootPosition, GameObject callingObject)
    {
        BulletBase bulletToShoot = PoolManager.instance.GetPooledObject(ObjectTypes.BulletStandard, callingObject).GetComponent<BulletBase>();
        bulletToShoot.transform.position = shootPosition.position;
        bulletToShoot.OnObjectDestroy += OnBulletDestroy;
        bulletToShoot.OnEnemyKill += OnEnemyKilled;
        bulletToShoot.OnEnemyHit += OnEnemyHit;
        bulletToShoot.Shoot(shootPosition.forward);
    }

}
