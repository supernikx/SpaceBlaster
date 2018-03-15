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
    GameObject ownerObject { get; set; }
    GameObject gameObject { get; }
    State CurrentState
    {
        get;
        set;
    }
    event PoolManagerEvets.Events OnObjectSpawn;
    event PoolManagerEvets.Events OnObjectDestroy;
}
