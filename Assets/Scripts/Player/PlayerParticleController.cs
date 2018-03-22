using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerParticleController : MonoBehaviour
{

    public ParticleSystem particleSystem;
    public PlayerMovement playerMovement;
    public float baseEffectDuration = 1.5f;


    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        /*var main = particleSystem.main;
        main.startLifetime = (playerMovement.YAxisMovement + baseEffectDuration)/2;*/

    }
}
