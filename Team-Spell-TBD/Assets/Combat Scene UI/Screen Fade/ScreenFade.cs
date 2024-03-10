using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private GameObject screenTint;
    private CanvasGroup alpha;
    void Start()
    {
        //Debug.Log("LOADED: Time scale" + Time.timeScale);
        Time.timeScale = 1.0f;
        //Debug.Log("Changed: Time scale" + Time.timeScale);
        screenTint.SetActive(true);
        alpha = screenTint.GetComponent<CanvasGroup>();
        alpha.alpha = 1f;
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        while (alpha.alpha > 0)
        {
            alpha.alpha -= Time.deltaTime;
            yield return null;
        }
        screenTint.SetActive(false);
    }
}
