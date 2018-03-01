using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Input Settings")]
    public KeyCode forwardInput = KeyCode.W;
    public KeyCode backwardInput = KeyCode.S;
    public KeyCode rightInput = KeyCode.D;
    public KeyCode leftInput = KeyCode.A;
    public float movementSpeed=0.2f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        //movimento in avanti
        if (Input.GetKey(forwardInput))
        {
            transform.position += Vector3.forward * movementSpeed;
        }
        //movimento indietro
        else if (Input.GetKey(backwardInput))
        {
            transform.position += Vector3.back * movementSpeed;
        }

        //movimento a destra
        if (Input.GetKey(rightInput))
        {
            transform.position += Vector3.right * movementSpeed;
        }
        //movimento a sinistra
        else if (Input.GetKey(leftInput))
        {
            transform.position += Vector3.left * movementSpeed;
        }
    }
}
