using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewEnemy", menuName = "Enemy")]
public class EnemyTypes : ScriptableObject {

    public float movementSpeed;
    public int life;
    public ShootTypes bulletType;
}
