using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public EnemyTypes enemyType;
    EnemyTypes instanceEnemy;

    BulletPoolManager bulletManager;

    public Transform shootPoint;

    float rateoTimer;

	// Use this for initialization
	void Start () {
        bulletManager = FindObjectOfType<BulletPoolManager>();
        Setup();
	}
	
	// Update is called once per frame
	void Update () {
        rateoTimer += Time.deltaTime;
        if (rateoTimer > instanceEnemy.bulletType.fireRateo)
        {
            Shoot();
            rateoTimer = 0;
        }
	}

    private void Setup()
    {
        if (!enemyType)
            return;
        instanceEnemy = Instantiate(enemyType);
    }

    private void Shoot()
    {
        Bullet bulletToShoot = bulletManager.GetBullet();
        bulletToShoot.transform.position = shootPoint.position;
        bulletToShoot.Shoot(transform.forward, instanceEnemy.bulletType.bulletForce);
    }
}
