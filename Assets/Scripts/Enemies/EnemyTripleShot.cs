using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTripleShot : EnemyBase {
    protected override ObjectTypes getID()
    {
        return ObjectTypes.EnemyTripleShot;
    }

    public override void Shoot()
    {
        float yRotation = 45f;
        for (int i = 0; i < 3; i++)
        {
            BulletBase bulletToShoot = pool.GetPooledObject(shootingBulletPrefab.objectID, gameObject).GetComponent<BulletBase>();
            bulletToShoot.transform.position = shootPoint.position;
            bulletToShoot.transform.rotation = Quaternion.Euler(0, yRotation+180, 0);
            bulletToShoot.Shoot(bulletToShoot.transform.forward);
            yRotation -= 45f;
        }
    }

    protected override void ShootRateo()
    {
        rateoTimer += Time.deltaTime;
        if (rateoTimer > shootingBulletPrefab.Stats.fireRate*2)
        {
            Shoot();
            rateoTimer = 0;
        }
    }

}
