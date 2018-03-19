using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IEnemy, IPoolManager, IDamageSystem
{
    #region VariablesDeclaration

    [Header("Stats Settings")]
    public EnemyStats Stats;
    private EnemyStats instanceStats;

    [Header("Shooting Settings")]
    public BulletBase shootingBullet;
    public Transform shootPoint;

    public ObjectTypes objectID
    {
        get
        {
            return getID();
        }
    }
    protected abstract ObjectTypes getID();

    private State _currentState;
    public State CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
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
    private GameObject ownerobject;

    protected PoolManager pool;
    private float rateoTimer;

    #endregion

    #region EventsDeclaration

    public event PoolManagerEvets.Events OnObjectSpawn;
    public event PoolManagerEvets.Events OnObjectDestroy;

    #endregion

    #region ScreenCheck
    protected float screenHeight;
    protected float screenWidth;
    private bool CheckScreenPosition()
    {
        if (transform.position.z < -screenHeight)
            return true;
        return false;
    }
    #endregion

    #region Shoot

    protected virtual void Shoot()
    {
        BulletBase bulletToShoot = pool.GetPooledObject(shootingBullet.objectID, gameObject).GetComponent<BulletBase>();
        bulletToShoot.transform.position = shootPoint.position;
        bulletToShoot.Shoot(transform.forward);
    }
    protected virtual void ShootRateo()
    {
        rateoTimer += Time.deltaTime;
        if (rateoTimer > shootingBullet.Stats.fireRate)
        {
            Shoot();
            rateoTimer = 0;
        }
    }

    #endregion

    private void Start()
    {
        StartDefault();
    }
    protected virtual void StartDefault()
    {
        pool = PoolManager.instance;
        screenHeight = Camera.main.orthographicSize-Camera.main.transform.position.z;
        screenWidth = (screenHeight * Screen.width / Screen.height)- transform.localScale.magnitude;
        Setup();
    }

    private void Update()
    {
        UpdateDefault();
    }
    protected virtual void UpdateDefault()
    {
        if (CurrentState == State.InUse)
        {
            ShootRateo();
            Movement();
            if (CheckScreenPosition())
                DestroyMe();
        }
    }

    protected virtual void Movement()
    {
        transform.position += transform.forward * instanceStats.movementSpeed * Time.deltaTime;
    }

    public virtual void Damaged(BulletBase bulletHitted)
    {
        if (bulletHitted.ownerObject.tag == "Player")
        {
            instanceStats.life -= bulletHitted.Stats.damage;
            if (instanceStats.life <= 0)
            {
                bulletHitted.OnEnemyKill(this, bulletHitted);
                DestroyMe();
            }
        }
    }

    private void Setup()
    {
        if (!Stats)
            return;
        instanceStats = Instantiate(Stats);
    }

    public virtual void Spawn(Vector3 spawnPosition)
    {
        CurrentState = State.InUse;
        if (OnObjectSpawn != null)
        {
            OnObjectSpawn(this);
        }
        rateoTimer = 0;
        transform.position = spawnPosition;
    }

    #region DestroyFunctions

    public void DestroyMe()
    {
        CurrentState = State.InPool;
        if (OnObjectDestroy != null)
            OnObjectDestroy(this);
    }

    public void DestroyVisualEffect()
    {

    }

    #endregion
}
