﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageSystem
{

    void Damaged(ShootTypes bulletType, BulletBase bulletHitted);
}
