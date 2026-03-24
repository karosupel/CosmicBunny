using UnityEngine;
using System.Collections;

public class FadingScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float duration = 1f;
    [SerializeField] float aplha_start;
    [SerializeField] float alpha_end;

    private void Awake()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(aplha_start, alpha_end));
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(aplha_start, alpha_end));
    }

    private IEnumerator Fade(float start, float end)
    {
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, time / duration);
            yield return null;
        }

        canvasGroup.alpha = end;
    }
}