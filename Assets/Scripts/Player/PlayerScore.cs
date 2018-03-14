using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    private int _score;

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            EventManager.OnScoreUpdated(this);
        }
    }

}
