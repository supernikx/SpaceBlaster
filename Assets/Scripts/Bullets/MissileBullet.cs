using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBullet : BulletBase
{
    protected override ObjectTypes getID()
    {
        return ObjectTypes.missileBullet;
    }


}
