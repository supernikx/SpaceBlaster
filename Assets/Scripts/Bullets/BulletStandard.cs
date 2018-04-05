using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStandard : BulletBase
{
    #region VariablesDeclarations
    protected override ObjectTypes getID()
    {
        return ObjectTypes.BulletStandard;
    }
    MeshRenderer mr;
    Collider collider;
    #endregion

    protected override void StartDefault()
    {
        base.StartDefault();
        mr = GetComponentInChildren<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    public override void DestroyMe()
    {
        transform.rotation = startRotation;
        base.DestroyMe();
    }

    #region Visual Effect
    public ParticleSystem particleSystem;
    public override void DestroyVisualEffect()
    {
        particleSystem.Play();
        mr.enabled = false;
        collider.enabled = false;
        Invoke("InvokeBaseVisualEffectDestroy", particleSystem.main.duration*2);
    }

    public void InvokeBaseVisualEffectDestroy()
    {
        base.DestroyVisualEffect();
        mr.enabled = true;
        collider.enabled = true;
    }

    #endregion
}
