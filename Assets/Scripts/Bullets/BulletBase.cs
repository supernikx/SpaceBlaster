using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class BulletBase : MonoBehaviour, IBullet, IPoolManager
{

    private State _currentState;
    public State CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }

    public event PoolManagerEvets.Events OnObjectSpawn;
    public event PoolManagerEvets.Events OnObjectDestroy;

    public ObjectTypes objectID
    {
        get
        {
            return getID();
        }
    }

    protected abstract ObjectTypes getID();

    public IBulletEvents.BulletKillEvent OnEnemyKill
    {

        get { return _OnEnemyKill; }
        set { _OnEnemyKill = value; }
    }
    private IBulletEvents.BulletKillEvent _OnEnemyKill;

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

    public void DestroyMe()
    {
        if (OnObjectDestroy != null)
            OnObjectDestroy(this);
    }

    public void DestroyVisualEffect()
    {
        CurrentState = State.InPool;
    }

    #region Shoot
    protected float force;
    protected Vector3 direction;
    public virtual void Shoot(Vector3 _direction, float _force, ShootTypes _shootingType)
    {
        if (OnObjectSpawn != null)
            OnObjectSpawn(this);
        direction = _direction;
        force = _force;
        shootingType = _shootingType;
    }
    #endregion

    public void Start()
    {
        screenHeight = Camera.main.orthographicSize;
    }

    private void FixedUpdate()
    {
        FixedUpdateDefault();
    }

    public virtual void FixedUpdateDefault()
    {
        if (CurrentState == State.InUse)
        {
            transform.position += direction * force;
            if (CheckScreenPosition())
                DestroyMe();
        }
    }

    private ShootTypes shootingType;
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterDefault(other);
    }

    protected virtual void OnTriggerEnterDefault(Collider other)
    {
        if (CurrentState == State.InUse)
        {
            IDamageSystem damaged = other.GetComponent<IDamageSystem>();
            if (damaged != null)
            {
                damaged.Damaged(shootingType, this);
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
