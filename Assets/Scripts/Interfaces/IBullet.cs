using UnityEngine;

public class IBulletEvents
{
    public delegate void BulletKillEvent(EnemyController enemyKilled, StandardBullet bullet);
}


public interface IBullet
{
    ObjectTypes objectID { get; }
    void Shoot(Vector3 _direction, float _force, ShootTypes _shootingType);
    void DestroyMe();
    void DestroyVisualEffect();
    IBulletEvents.BulletKillEvent OnEnemyKill { get; set; }

}
