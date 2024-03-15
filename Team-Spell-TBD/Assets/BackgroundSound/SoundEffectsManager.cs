using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to an empty game object (A sound effect manager) 
// Assign SoundFXObject prefab to this script's soundFXObject
// followed tutorial: https://www.youtube.com/watch?v=DU7cgVsU2rM 

public class SoundEffectsManager : MonoBehaviour
{
    // Create a singleton (let's you call it easily from everywhere)
    public static SoundEffectsManager instance;
    // you can call public functions in this script by using "SoundFXManager.instance.[function name]([parameters])"

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign the audioClip
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //destroy clip after it is done playing
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
