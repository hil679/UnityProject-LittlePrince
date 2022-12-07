using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Samples.VrHoops;
using SpaceGraphicsToolkit.Cloudsphere;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            if (_instance == null)
            {
                GameObject container = new GameObject("GameManager");
                _instance = container.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public Slider ConfidenceBar;



    public void Start()
    {   
        if (SceneManager.GetActiveScene().name == "Earth_plane")
            PlayerPrefs.SetFloat("Confidence", 0.0f);
        ConfidenceBar.value = PlayerPrefs.GetFloat("Confidence", 0.0f);
        

    }
    // Start is called before the first frame update

    public void Confidence(float value)
    {
        ConfidenceBar.value += value;
        PlayerPrefs.SetFloat("Confidence", ConfidenceBar.value);
        
    }

    public void RewardSelect()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Dino_Sample")
        {
            
            PlayerPrefs.SetString("Dino_reward", clickObject.name);

        }
    }
}
