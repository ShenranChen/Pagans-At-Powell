using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour
{
    public AudioClip buttonPressed;
    public Transform player;

    public void BtnPressSound()
    {
        SoundEffectsManager.instance.PlaySoundFXClip(buttonPressed, player, PlayerPrefs.GetFloat("volume"));
    }
}
