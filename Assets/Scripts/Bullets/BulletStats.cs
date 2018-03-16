using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewShoot", menuName = "BulletStats")]
public class BulletStats : ScriptableObject
{
    public float fireRate;
    public float bulletSpeed;
    public int damage;

}
