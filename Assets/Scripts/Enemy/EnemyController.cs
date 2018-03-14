using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IPoolManager, IDamageSystem
{
    #region TypesDeclarations
    public delegate void EnemyEvent(EnemyController enemy);
    public State Currentstate
    {
        get
        {
            return currentState;
        }

        set
        {
            currentState = value;
        }
    }
    public GameObject ownerObject
    {
        get
        {
            return ownerobject;
        }
        set
        {
            ownerobject = value;
        }
    }
    #endregion
    #region VariablesDeclarations
    public EnemyTypes enemyType;
    EnemyTypes instanceEnemy;
    PoolManager pool;
    private State currentState;
    public Transform shootPoint;
    private float rateoTimer;
    public event PoolManagerEvets.Events OnObjectSpawn;
    public event PoolManagerEvets.Events OnObjectDestroy;
    private GameObject ownerobject;
    #endregion

    // Use this for initialization
    void Start()
    {
        pool = PoolManager.instance;
        screenHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Currentstate == State.InUse)
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
        if (OnObjectSpawn != null)
        {
            OnObjectSpawn(this);
        }
        rateoTimer = 0;
        enemyType = type;
        Setup();
        transform.position = spawnPosition;
    }

    public void KillMe()
    {
        if (OnObjectDestroy != null)
            OnObjectDestroy(this);
    }

    public void Damaged(ShootTypes bulletType, Bullet bulletHitted)
    {
        if (bulletHitted.ownerObject.tag == "Player")
        {
            instanceEnemy.life -= bulletType.damage;
            if (instanceEnemy.life <= 0)
            {
                bulletHitted.OnEnemyKill(this, bulletHitted);
                KillMe();
            }
        }
    }

    private void Shoot()
    {
        Bullet bulletToShoot = pool.GetPooledObject(ObjectTypes.bullet, gameObject).GetComponent<Bullet>();
        bulletToShoot.transform.position = shootPoint.position;
        bulletToShoot.Shoot(transform.forward, instanceEnemy.bulletType.bulletForce, instanceEnemy.bulletType);
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
