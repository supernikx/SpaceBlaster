using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour {
    Vector3 bulletPoolPosition = new Vector3(1000, 1000, 1000);
    public Bullet bulletPrefab;
    public int maxBullets=20;
    List<Bullet> bullets = new List<Bullet>();

    private void Start()
    {
        for (int i = 0; i < maxBullets; i++)
        {
            Bullet bulletToAdd = Instantiate(bulletPrefab,transform);
            bulletToAdd.OnShoot += OnBulletShoot;
            bulletToAdd.OnDestroy += OnBulletDestroy;
            OnBulletDestroy(bulletToAdd);
            bullets.Add(bulletToAdd);
        }
    }

    private void OnBulletDestroy(Bullet bullet)
    {
        bullet.transform.position = bulletPoolPosition;
    }

    private void OnBulletShoot(Bullet bullet)
    {
       
    }

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in bullets)
        {
            if (bullet.currentState == Bullet.State.InPool)
                return bullet;
        }
        Debug.Log("Nessun proiettile disponibile");
        return null;
    }

    private void OnDisable()
    {
        foreach (Bullet bullet in bullets)
        {
            bullet.OnShoot -= OnBulletShoot;
            bullet.OnDestroy -= OnBulletDestroy;
        }
    }
}
