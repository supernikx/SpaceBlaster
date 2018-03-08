using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    public Text scoreText;
    public int score;

    private void Start()
    {
        score = 0;
    }

    public void OnBulletCollision(Bullet bullet,Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyController enemyToKill = other.GetComponent<EnemyController>();
            score += enemyToKill.enemyType.score;
            scoreText.text = "SCORE = " + score;
            enemyToKill.KillMe();
            bullet.OnBulletCollision -= OnBulletCollision;
        }
    }
}
