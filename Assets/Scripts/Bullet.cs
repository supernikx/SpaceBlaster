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
        mainCamera = FindObjectOfType<Camera>();
        screenWorldunitDimension = mainCamera.ScreenToWorldPoint(new Vector2(Screen.height, Screen.width));
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

    private void OnCollisionEnter(Collision collision)
    {
        if (currentState == State.InPool)
        {
            DestroyMe();
        }
    }

    #region ScreenCheck
    Camera mainCamera;
    Vector2 screenWorldunitDimension;
    private bool CheckScreenPosition()
    {
        if (transform.position.z > screenWorldunitDimension.y)
            return true;
        return false;
    }
    #endregion
}
