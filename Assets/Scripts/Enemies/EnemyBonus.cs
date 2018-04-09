using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBonus : EnemyBase {
    [Header("Drop Settings")]
    protected override ObjectTypes getID()
    {
        return ObjectTypes.EnemyBonus;
    }

    protected override void UpdateDefault()
    {
        Movement();
        if (CheckScreenPosition())
            DestroyBehaviour();
    }

    public override void DestroyMe()
    {
        if (FindObjectOfType<PlayerInventory>().AddWeapon(typeof(WeaponTriple)))
        {
            base.DestroyMe();
        }
    }
}
