using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolManager
{
    #region TypesDeclarations
    public delegate void BulletCollisionEvent(Bullet bullet, Collider collider);
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
    #endregion
    #region VariablesDeclarations
    public event PoolManagerEvets.Events OnObjectSpawn;
    public event PoolManagerEvets.Events OnObjectDestroy;
    public BulletCollisionEvent OnBulletCollision;
    private State currentState;
    #endregion

    #region API
    public void DestroyMe()
    {
        if (OnObjectDestroy != null)
            OnObjectDestroy(this);
    }

    #region Shoot
    float force;
    Vector3 direction;
    public void Shoot(Vector3 _direction, float _force)
    {
        if (OnObjectSpawn != null)
            OnObjectSpawn(this);
        direction = _direction;
        force = _force;
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
            if (OnBulletCollision != null)
            {
                OnBulletCollision(this, other);
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
