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

    private void Start()
    {
        screenHeight = Camera.main.orthographicSize;
    }

    private void Update()
    {
        if (currentState == State.InUse)
        {
            transform.position += direction * force;
            if (CheckScreenPosition())
                DestroyMe();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentState == State.InPool)
        {
            DestroyMe();
        }
        Debug.Log("sos");
    }

    #region ScreenCheck
    float screenHeight;
    private bool CheckScreenPosition()
    {
        if (transform.position.z > screenHeight*2 || transform.position.z < -screenHeight)
            return true;
        return false;
    }
    #endregion
}
