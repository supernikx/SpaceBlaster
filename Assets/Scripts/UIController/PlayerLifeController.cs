using UnityEngine;
using TMPro;

public class PlayerLifeController : MonoBehaviour {

    public TextMeshProUGUI scoreText;
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
