using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {
    [Header("Shoot Settings")]
    public KeyCode shootInput = KeyCode.Space;
    public ShootTypes shoottype;
    public Transform shootPosition;
    PlayerScore playerScore;
    PoolManager pool;

    private void Awake()
    {
        pool = PoolManager.instance;
        playerScore = GetComponent<PlayerScore>();
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
        Bullet bulletToShoot = pool.GetPooledObject(ObjectTypes.bullet).GetComponent<Bullet>();
        bulletToShoot.OnBulletCollision += playerScore.OnBulletCollision;
        bulletToShoot.transform.position = shootPosition.position;
        bulletToShoot.Shoot(transform.forward,shoottype.bulletForce);
    }
}
