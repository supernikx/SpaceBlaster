using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShoot", menuName = "Shoot")]
public class ShootTypes : ScriptableObject
{
    public float fireRateo;
    public float bulletForce;
    public int damage;
}
