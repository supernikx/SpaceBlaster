using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [Header("Audio Clips")]
    public AudioClip EnviromentClip;
    public AudioClip OnShootClip;
    public AudioClip OnBulletDestroyClip;
    public AudioClip OnShipDestroyClip;

    [Header("Audio Sources")]
    public AudioSource EnviromentTrack;
    public AudioSource SFXTrack;

    private void OnEnable()
    {
        PoolManager.instance.OnObjectPooled += OnObjectPooled;
    }

    private void OnDisable()
    {
        PoolManager.instance.OnObjectPooled -= OnObjectPooled;
    }

    private void OnObjectPooled(IPoolManager pooledObject)
    {
        pooledObject.OnObjectDestroy += OnPooledObjectDestroy;
    }

    private void OnPooledObjectDestroy(IPoolManager objectDestroy)
    {
        objectDestroy.OnObjectDestroy -= OnPooledObjectDestroy;
        if (objectDestroy.gameObject.GetComponent<IBullet>() != null)
        {
            SetSFXTrack(OnBulletDestroyClip);
        }
    }

    // Use this for initialization
    void Start () {
        SetEnviromentClip();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetEnviromentClip()
    {
        if (EnviromentClip != null)
        {
            EnviromentTrack.clip = EnviromentClip;
            EnviromentTrack.loop = true;
            EnviromentTrack.Play();
        }
    }

    public void SetSFXTrack(AudioClip clipToSet)
    {
        if (EnviromentClip != null)
        {
            SFXTrack.clip = clipToSet;
            SFXTrack.Play();
        }
    }
}
