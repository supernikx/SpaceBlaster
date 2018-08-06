using UnityEngine;
using TMPro;

public class PlayerScoreController : MonoBehaviour {

    public TextMeshProUGUI scoreText;
    public PlayerScore playerToCheck;

    private void OnEnable()
    {
        EventManager.OnScoreUpdated += ScoreUpdate;
    }

    private void OnDisable()
    {
        EventManager.OnScoreUpdated -= ScoreUpdate;
    }

    private void ScoreUpdate(PlayerScore player)
    {
        if (playerToCheck == player)
        {
            scoreText.text = "SCORE = " + player.Score.ToString();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
