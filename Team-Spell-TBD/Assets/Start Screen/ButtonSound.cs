using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource buttonHover;
    public AudioSource buttonPressed;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonHover.volume = PlayerPrefs.GetFloat("volume");
        buttonHover.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonHover.Stop();
    }

    public void BtnPressSound()
    {
        buttonPressed.volume = PlayerPrefs.GetFloat("volume") * 0.3f;
        buttonPressed.Play();
    }
}
