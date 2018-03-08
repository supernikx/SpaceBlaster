using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {
    [Header("Shoot Settings")]
    public KeyCode shootInput = KeyCode.Space;
    public ShootTypes shoottype;
    public Transform shootPosition;
    PlayerScore playerScore;

    BulletPoolManager bulletManager;

    private void Awake()
    {
        bulletManager = FindObjectOfType<BulletPoolManager>();
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
        Bullet bulletToShoot = bulletManager.GetBullet();
        bulletToShoot.OnBulletCollision += playerScore.OnBulletCollision;
        bulletToShoot.transform.position = shootPosition.position;
        bulletToShoot.Shoot(transform.forward,shoottype.bulletForce);
    }
}
