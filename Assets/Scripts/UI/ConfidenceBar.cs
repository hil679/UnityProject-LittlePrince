using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfidenceBar : MonoBehaviour
{
    [SerializeField] private GameObject confiImage;

    [SerializeField] private GameObject confiSlider;

    private Slider _confidenceSlider;
    // Start is called before the first frame update

    public void Awake()
    {
        _confidenceSlider = GetComponentInChildren<Slider>();
    }

    public IEnumerator Start()
    {
        GetComponent<Transform>().localScale.Set(1.5f, 1.5f, 1.0f); 
        confiImage.GetComponent<UIFade>().StartFadeIn();
        confiSlider.GetComponent<UIFade>().StartFadeIn();
        yield return new WaitForSeconds(1);
        float confiIncrease = GameManager.Instance.confidence;
        float start = PlayerPrefs.GetFloat("Confidence");
        float time = 0;
        while (_confidenceSlider.value < start + confiIncrease)
        {
            time += Time.deltaTime / 1.5f;
            
            _confidenceSlider.value = Mathf.Lerp(start, start+confiIncrease, time);
        }
        PlayerPrefs.SetFloat("Confidence", _confidenceSlider.value);
        
        yield return new WaitForSeconds(2);
        confiImage.GetComponent<UIFade>().StartFadeOut();
        confiSlider.GetComponent<UIFade>().StartFadeOut();
    }
}
