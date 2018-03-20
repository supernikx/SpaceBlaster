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
    #endregion

    public override void DestroyMe()
    {
        transform.rotation = startRotation;
        base.DestroyMe();
    }
}
