using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {
    public float backgoundDislpace = 40.90001f;
    public float backgroundspeed=0.5f;
    public BackgroundController bg1;
    public BackgroundController bg2;
    BackgroundController currentBG;

	// Use this for initialization
	void Start () {
        currentBG = bg1;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, 0, -backgroundspeed);
	}

    public void RespawnBG(BackgroundController bg)
    {
        if (bg != currentBG)
            return;
        BackgroundController other = (bg == bg1) ? bg2 : bg1;
        bg.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z+backgoundDislpace);
        currentBG = other;
    }
}
