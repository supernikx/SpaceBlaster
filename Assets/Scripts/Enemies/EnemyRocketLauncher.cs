using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocketLauncher : EnemyBase
{
    float screenWidth;
    bool right;
    protected override ObjectTypes getID()
    {
        return ObjectTypes.EnemyRocketLauncher;
    }

    protected override void StartDefault()
    {
        base.StartDefault();
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect - transform.localScale.magnitude;
    }

    protected override void Movement()
    {
        if (right)
        {
            transform.position += transform.right * Stats.movementSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += -transform.right * Stats.movementSpeed * Time.deltaTime;
        }

        if (transform.position.x>screenWidth || transform.position.x < -screenWidth)
        {
            transform.position += new Vector3(0, 0, -2f);
            right = !right;
        }
    }
}
