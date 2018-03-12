using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageSystem : MonoBehaviour, IDamageSystem
{

    [Header("Life")]
    public Text lifeText;
    public int life;

    [Header("Score")]
    public Text scoreText;
    public int score;


    private void Start()
    {
        score = 0;
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
        score += enemyKilled.GetComponent<EnemyController>().enemyType.score;
        scoreText.text = "SCORE = " + score;
    }

    public void KillMe()
    {

    }
}
