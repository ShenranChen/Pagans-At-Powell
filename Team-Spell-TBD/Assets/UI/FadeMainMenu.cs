using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMainMenu : MonoBehaviour
{
    public CanvasGroup uiGroup;
    public float fadeDuration = 1f;

    private void Start()
    {
        uiGroup.alpha = 1;
    }

    // Call this method to start fading in
    public void FadeIn()
    {
        StartCoroutine(DoFade(uiGroup, uiGroup.alpha, 1));
    }

    // Call this method to start fading out
    public void FadeOut()
    {
        StartCoroutine(DoFade(uiGroup, uiGroup.alpha, 0));
    }

    private IEnumerator DoFade(CanvasGroup group, float start, float end)
    {
        float counter = 0f;
        while (counter < fadeDuration)
        {
            counter += Time.deltaTime;
            group.alpha = Mathf.Lerp(start, end, counter / fadeDuration);

            yield return null;
        }
    }
}
