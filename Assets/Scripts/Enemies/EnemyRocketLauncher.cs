using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocketLauncher : EnemyBase
{
    bool right;
    Vector3 oldPosition;
    protected override ObjectTypes getID()
    {
        return ObjectTypes.EnemyRocketLauncher;
    }

    public override void Spawn(Vector3 spawnPosition)
    {
        base.Spawn(spawnPosition);
        right = Random.Range(0, 2) % 2 == 0;
    }

    public override void Movement()
    {
        if ((transform.position.x > screenWidth || transform.position.x < -screenWidth) && (oldPosition.z - 3f < transform.position.z))
        {
            transform.position += transform.forward * Stats.movementSpeed * Time.deltaTime;
            if (oldPosition.z - 3f > transform.position.z)
                right = !right;
        }
        else
        {
            if (right)
            {
                oldPosition = transform.position += transform.right * Stats.movementSpeed * Time.deltaTime;
            }
            else
            {
                oldPosition = transform.position += -transform.right * Stats.movementSpeed * Time.deltaTime;
            }
        }
    }

}
