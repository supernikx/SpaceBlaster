using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTriple : WeaponBase {

    public override void Shoot(Transform shootPosition, GameObject callingObject)
    {
        float yRotation = 45f;
        for (int i = 0; i < 3; i++)
        {
            BulletBase bulletToShoot = pool.GetPooledObject(ObjectTypes.BulletStandard, callingObject).GetComponent<BulletBase>();
            bulletToShoot.transform.position = shootPosition.position;
            bulletToShoot.transform.rotation = Quaternion.Euler(0, yRotation, 0);
            bulletToShoot.OnObjectDestroy += OnBulletDestroy;
            bulletToShoot.OnEnemyKill += OnEnemyKilled;
            bulletToShoot.OnEnemyHit += OnEnemyHit;
            bulletToShoot.Shoot(bulletToShoot.transform.forward);
            yRotation -= 45f;
        }
    }
}
