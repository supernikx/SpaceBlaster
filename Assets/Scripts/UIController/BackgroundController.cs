using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    float screenHeight;
    public Bounds bound;
    BackgroundManager bgManager;

    private bool CheckScreenPosition()
    {
        if (bound.extents.z + transform.position.z < -screenHeight)
            return true;
        return false;
    }

    // Use this for initialization
    void Start()
    {
        bgManager = FindObjectOfType<BackgroundManager>();
        screenHeight = Camera.main.orthographicSize - Camera.main.transform.position.z;
        bound = GetComponent<SpriteRenderer>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckScreenPosition())
            bgManager.RespawnBG(this);
    }
}
