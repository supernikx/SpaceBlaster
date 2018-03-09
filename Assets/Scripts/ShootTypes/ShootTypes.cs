using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewShoot", menuName = "Shoot")]
public class ShootTypes : ScriptableObject
{
    public float fireRateo;
    public float bulletForce;
    public int damage;
}
