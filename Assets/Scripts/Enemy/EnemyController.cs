using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    #region TypesDeclarations
    public enum State
    {
        InPool,
        InUse,
    }
    public delegate void EnemyEvent(EnemyController enemy);
    #endregion
    #region VariablesDeclarations
    public State currentState = State.InPool;
    public EnemyEvent OnSpawn;
    public EnemyEvent OnDestroy;
    public EnemyTypes enemyType;
    EnemyTypes instanceEnemy;
    BulletPoolManager bulletManager;
    public Transform shootPoint;
    float rateoTimer;
    #endregion

    // Use this for initialization
    void Start()
    {
        bulletManager = FindObjectOfType<BulletPoolManager>();
        screenHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.InUse)
        {
            #region ShootRateo
            rateoTimer += Time.deltaTime;
            if (rateoTimer > instanceEnemy.bulletType.fireRateo)
            {
                Shoot();
                rateoTimer = 0;
            }
            #endregion
            #region Movement
            transform.position += transform.forward * enemyType.movementSpeed;
            if (CheckScreenPosition())
            {
                KillMe();
            }
            #endregion
        }

    }

    private void Setup()
    {
        if (!enemyType)
            return;
        instanceEnemy = Instantiate(enemyType);
    }

    public void Spawn(Vector3 spawnPosition, EnemyTypes type)
    {
        rateoTimer = 0;
        enemyType = type;
        Setup();
        currentState = State.InUse;
        transform.position = spawnPosition;
    }

    public void KillMe()
    {
        currentState = State.InPool;
        if (OnDestroy != null)
            OnDestroy(this);
    }

    private void Shoot()
    {
        Bullet bulletToShoot = bulletManager.GetBullet();
        bulletToShoot.transform.position = shootPoint.position;
        bulletToShoot.Shoot(transform.forward, instanceEnemy.bulletType.bulletForce);
    }

    #region ScreenCheck
    float screenHeight;
    private bool CheckScreenPosition()
    {
        if (transform.position.z < -screenHeight)
            return true;
        return false;
    }
    #endregion
}
