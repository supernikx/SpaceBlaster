using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {
    [Header("Shoot Settings")]
    public KeyCode shootInput = KeyCode.Space;
    public ShootTypes shoottype;
    public Transform shootPosition;

    BulletPoolManager bulletManager;

    private void Awake()
    {
        bulletManager = FindObjectOfType<BulletPoolManager>();
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
        Bullet bulletToShoot = bulletManager.GetBullet();
        bulletToShoot.transform.position = shootPosition.position;
        bulletToShoot.Shoot(transform.forward,shoottype.bulletForce);
    }
}
