using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void EventScore(PlayerScore player);
    public static EventScore OnScoreUpdated;

}
