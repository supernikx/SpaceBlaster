using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class BulletBase : MonoBehaviour, IBullet, IPoolManager
{
    #region variablesDeclarations

    public BulletStats Stats;

    private State _currentState;
    public State CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }

    public ObjectTypes objectID
    {
        get
        {
            return getID();
        }
    }
    protected abstract ObjectTypes getID();

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

    protected Quaternion startRotation;

    #endregion

    #region EventsDeclarations

    public event PoolManagerEvets.Events OnObjectSpawn;
    public event PoolManagerEvets.Events OnObjectDestroy;

    public IBulletEvents.BulletKillEvent OnEnemyKill
    {

        get { return _OnEnemyKill; }
        set { _OnEnemyKill = value; }
    }
    private IBulletEvents.BulletKillEvent _OnEnemyKill;
    public IBulletEvents.BulletKillEvent OnEnemyHit
    {

        get { return _OnEnemyHit; }
        set { _OnEnemyHit = value; }
    }
    private IBulletEvents.BulletKillEvent _OnEnemyHit;

    #endregion

    #region DestroyFunctions



    public virtual void DestroyMe()
    {

        DestroyVisualEffect();
        if (OnObjectDestroy != null)
            OnObjectDestroy(this);
    }

    public virtual void DestroyVisualEffect()
    {
        CurrentState = State.Destroying;
    }

    #endregion

    #region Shoot
    protected Vector3 direction;
    public virtual void Shoot(Vector3 _direction)
    {
        if (OnObjectSpawn != null)
            OnObjectSpawn(this);
        direction = _direction;
    }
    #endregion

    #region ScreenCheck
    float screenHeight;

    private bool CheckScreenPosition()
    {
        if (transform.position.z > screenHeight || transform.position.z < -screenHeight)
            return true;
        return false;
    }
    #endregion

    private void Start()
    {
        StartDefault();
    }

    protected virtual void StartDefault()
    {
        screenHeight = Camera.main.orthographicSize - Camera.main.transform.position.z;
        startRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        FixedUpdateDefault();
    }

    protected virtual void FixedUpdateDefault()
    {
        if (CurrentState == State.InUse)
        {
            transform.position += direction * Stats.bulletSpeed;
            if (CheckScreenPosition())
                DestroyMe();
        }
    }

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
                damaged.Damaged(this);
                DestroyMe();
            }           
        }
    }
}
