using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerEvets{
    public delegate void Events(IPoolManager _gameObject);
}

public enum State
{
    InPool,
    InUse,
    Destroying,
}

public interface IPoolManager {
    State Currentstate { get; set; }
    GameObject ownerObject { get; set; }
    GameObject gameObject { get; }
    event PoolManagerEvets.Events OnObjectSpawn;
    event PoolManagerEvets.Events OnObjectDestroy;
}
