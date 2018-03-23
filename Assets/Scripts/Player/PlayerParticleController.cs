using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerParticleController : MonoBehaviour
{

    public ParticleSystem particleSystem;
    public PlayerMovement playerMovement;


    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        var mainModule = particleSystem.main;
        
        if (playerMovement.YAxisMovement == 1)
        {
            mainModule.startLifetime = new ParticleSystem.MinMaxCurve(0.3f, 0.4f);
        }
        else if (playerMovement.YAxisMovement == -1)
        {
            mainModule.startLifetime = new ParticleSystem.MinMaxCurve(0.1f, 0.2f);
        }
        else
        {
            mainModule.startLifetime = new ParticleSystem.MinMaxCurve(0.2f, 0.3f);
        }
        

    }
}
