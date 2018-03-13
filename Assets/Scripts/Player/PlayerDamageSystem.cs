using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerScore))]
public class PlayerDamageSystem : MonoBehaviour, IDamageSystem
{

    [Header("Life")]
    public Text lifeText;
    public int life;

    PlayerScore ScoreController;

    private void Start()
    {
        ScoreController = GetComponent<PlayerScore>();
    }

    public void Damaged(ShootTypes bulletType, Bullet bulletHitted)
    {
        if (bulletHitted.ownerObject.tag == "Enemy")
        {
            life -= bulletType.damage;
            lifeText.text = "LIFE = " + life;
            if (life <= 0)
            {
                bulletHitted.ownerObject.GetComponent<IDamageSystem>().KilledEnemy(gameObject);
                KillMe();
            }
        }
    }

    public void KilledEnemy(GameObject enemyKilled)
    {
        ScoreController.Score += enemyKilled.GetComponent<EnemyController>().enemyType.score;
    }

    public void KillMe()
    {

    }
}
