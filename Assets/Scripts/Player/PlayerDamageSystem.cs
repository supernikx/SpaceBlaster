using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageSystem : MonoBehaviour, IDamageSystem
{

    [Header("Life")]
    public int life;

    public void Damaged(ShootTypes bulletType, StandardBullet bulletHitted)
    {
        if (bulletHitted.ownerObject.tag == "Enemy")
        {
            life -= bulletType.damage;
            EventManager.OnPlayerDamaged(this);
            if (life <= 0)
            {
                KillMe();
            }
        }
    }

    public void KillMe()
    {
        gameObject.SetActive(false);
        Debug.Log("Game Over");
    }
}
