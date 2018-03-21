using UnityEngine;

public interface IEnemy {

    ObjectTypes objectID { get; }
    void DestroyMe();
    void DestroyVisualEffect();
    void Shoot();
    void Movement();
    void Spawn(Vector3 spawnPosition);
    EnemyStats instanceStats { get; }
}
