using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonHoverSounds : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioClip buttonHover;
    [SerializeField] private Transform player;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter");
        SoundEffectsManager.instance.PlaySoundFXClip(buttonHover, player, PlayerPrefs.GetFloat("volume"));
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
