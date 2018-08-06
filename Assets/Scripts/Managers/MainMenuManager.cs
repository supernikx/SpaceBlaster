using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

    private void OnEnable()
    {
        Screen.SetResolution(540, 960, false);
    }

    // Use this for initialization
    void Start () {        
        Time.timeScale = 0f;
	}

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
