using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeController : MonoBehaviour {

    public Text scoreText;
    public PlayerDamageSystem playerToCheck;

    private void OnEnable()
    {
        EventManager.OnPlayerDamaged += PlayerDamaged;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerDamaged -= PlayerDamaged;
    }

    private void PlayerDamaged(PlayerDamageSystem player)
    {
        if (playerToCheck == player)
        {
            scoreText.text = "LIFE = " + player.life;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
