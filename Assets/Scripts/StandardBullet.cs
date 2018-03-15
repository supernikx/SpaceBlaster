using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBullet : MonoBehaviour, IPoolManager,IBullet
{
    #region TypesDeclarations
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
    public IBulletEvents.BulletKillEvent OnEnemyKill
    {
        get
        {
            return _OnEnemyKill;
        }

        set
        {
            _OnEnemyKill = value;
        }
    }
    #endregion
    #region VariablesDeclarations
    public event PoolManagerEvets.Events OnObjectSpawn;
    public event PoolManagerEvets.Events OnObjectDestroy;
    private IBulletEvents.BulletKillEvent _OnEnemyKill;
    ShootTypes shootingType;
    private State currentState;
    private GameObject ownerobject;
    #endregion

    #region API
    public void DestroyMe()
    {
        Currentstate = State.Destroying;
        if (OnObjectDestroy != null)
            OnObjectDestroy(this);
    }

    public void DestroyVisualEffect()
    {
        Currentstate = State.InPool;
    }

    #region Shoot
    float force;
    Vector3 direction;
    public void Shoot(Vector3 _direction, float _force, ShootTypes _shootingType)
    {
        if (OnObjectSpawn != null)
            OnObjectSpawn(this);
        direction = _direction;
        force = _force;
        shootingType = _shootingType;
    }
    #endregion

    #endregion

    private void Start()
    {
        screenHeight = Camera.main.orthographicSize;
    }

    private void Update()
    {
        if (Currentstate == State.InUse)
        {
            transform.position += direction * force;
            if (CheckScreenPosition())
                DestroyMe();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Currentstate == State.InUse)
        {
            IDamageSystem damaged = other.GetComponent<IDamageSystem>();
            if (damaged != null)
            {
                damaged.Damaged(shootingType,this);
            }
            DestroyMe();
        }
    }

    #region ScreenCheck
    float screenHeight;
    private bool CheckScreenPosition()
    {
        if (transform.position.z > screenHeight * 2 || transform.position.z < -screenHeight)
            return true;
        return false;
    }
    #endregion
}
