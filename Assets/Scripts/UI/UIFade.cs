using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public float fadeInTime;
    public float fadeOutTime;

    private Image fadeImage;

    private float inStart = 1.0f;
    private float inEnd = 0;
    private float outStart = 0;
    private float outEnd = 1.0f;
    private float time = 0;

    private bool isPlaying = false;
    // Start is called before the first frame update

    void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    private void Start()
    {
        StartCoroutine("FadeIn");
    }

    public void StartFadeIn()
    {
        // 애니메이션이 재생중이면 중복 재생되지 않도록 리턴 처리.  
        if (isPlaying == true)
            return;

        // Fade 애니메이션 재생.  
        StartCoroutine("FadeIn");
    }

    public void StartFadeOut()
    {
        if (isPlaying == true)
            return;

        StartCoroutine("FadeOut");
    }

    private IEnumerator FadeIn()
    {
        // 애니메이션 재생중.  


        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = fadeImage.color;
        time = 0f;
        color.a = Mathf.Lerp(inStart, inEnd, time);

        while (color.a > 0f)
        {
            // 경과 시간 계산.  
            // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
            time += Time.deltaTime / fadeInTime;

            // 알파 값 계산.  
            color.a = Mathf.Lerp(inStart, inEnd, time);
            // 계산한 알파 값 다시 설정.  
            fadeImage.color = color;

            yield return null;
        }

        // 애니메이션 재생 완료.  
        isPlaying = false;
    }

    // Fade 애니메이션 메소드.  
    private IEnumerator FadeOut()
    {
        // 애니메이션 재생중.  
        isPlaying = true;

        // Image 컴포넌트의 색상 값 읽어오기.  
        Color color = fadeImage.color;
        time = 0f;
        color.a = Mathf.Lerp(outStart, outEnd, time);

        while (color.a < 1f)
        {
            // 경과 시간 계산.  
            // 2초(animTime)동안 재생될 수 있도록 animTime으로 나누기.  
            time += Time.deltaTime / fadeOutTime;

            // 알파 값 계산.  
            color.a = Mathf.Lerp(outStart, outEnd, time);
            // 계산한 알파 값 다시 설정.  
            fadeImage.color = color;

            yield return null;
        }

        // 애니메이션 재생 완료.  
        isPlaying = false;
    }
}
