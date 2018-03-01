using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region TypesDeclarations
    public enum State
    {
        InPool,
        InUse,
    }
    public delegate void BulletEvent(Bullet bullet);
    #endregion
    #region VariablesDeclarations
    public State currentState = State.InPool;
    public BulletEvent OnShoot;
    public BulletEvent OnDestroy;
    #endregion

    #region API
    public void DestroyMe()
    {
        currentState = State.InPool;
        if (OnDestroy != null)
            OnDestroy(this);
    }

    #region Shoot
    float force;
    Vector3 direction;

    public void Shoot(Vector3 _direction, float _force)
    {
        currentState = State.InUse;
        if (OnShoot != null)
            OnShoot(this);
        direction = _direction;
        force = _force;

    }
    #endregion

    #endregion


    private void Update()
    {
        if (currentState == State.InUse)
        {
            transform.position += direction * force;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentState == State.InPool)
        {
            DestroyMe();
        }
    }
}
