using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewEnemy", menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject {

    public float movementSpeed;
    public int life;
    public int score;

}
