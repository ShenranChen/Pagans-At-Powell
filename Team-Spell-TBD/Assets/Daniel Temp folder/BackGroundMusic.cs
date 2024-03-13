using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class BackGroundMusic : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private AudioClip backgroundMusicClip;

    private float musicLength;
    private float musicTimer;

    // Start is called before the first frame update
    void Start()
    {
        SoundEffectsManager.instance.PlaySoundFXClip(backgroundMusicClip, playerTransform, PlayerPrefs.GetFloat("volume") / 2f);
        musicLength = backgroundMusicClip.length;
    }

    void Update()
    {
        if (musicTimer > 0f) { musicTimer -= Time.deltaTime; }
        if (musicTimer <= 0f)
        {
            musicTimer = musicLength;
            SoundEffectsManager.instance.PlaySoundFXClip(backgroundMusicClip, playerTransform, PlayerPrefs.GetFloat("volume") / 2f);
        }
    }
}
