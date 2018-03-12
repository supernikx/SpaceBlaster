using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {
    [Header("Shoot Settings")]
    public KeyCode shootInput = KeyCode.Space;
    public ShootTypes shoottype;
    public Transform shootPosition;
    PoolManager pool;

    private void Awake()
    {

    }

    private void Start()
    {
        pool = PoolManager.instance;   
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
        Bullet bulletToShoot = pool.GetPooledObject(ObjectTypes.bullet,gameObject).GetComponent<Bullet>();
        bulletToShoot.transform.position = shootPosition.position;
        bulletToShoot.Shoot(transform.forward, shoottype.bulletForce,shoottype);
    }
}
