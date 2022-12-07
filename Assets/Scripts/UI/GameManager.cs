using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Samples.VrHoops;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider ConfidenceBar;
    public float ConfidenceIncrease;
    
    

    public void Start()
    {   
        PlayerPrefs.SetFloat("Confidence", 0.0f);
        ConfidenceBar.value = PlayerPrefs.GetFloat("Confidence", 0.0f);
        

    }
    // Start is called before the first frame update

    public void Confidence()
    {
        ConfidenceBar.value += ConfidenceIncrease;
        PlayerPrefs.SetFloat("Confidence", ConfidenceBar.value);
        
    }
}
