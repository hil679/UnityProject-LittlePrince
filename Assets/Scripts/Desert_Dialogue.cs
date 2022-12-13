using System.Collections;
using System.Collections.Generic;
using BNG;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Desert_Dialogue : MonoBehaviour
{
    [SerializeField] private DialogueSystem[] dialogs;
    [SerializeField] private SnakeMove Snake;
    [SerializeField] private GameObject RewardUI;
    
    
    private static Desert_Dialogue _instance;
    public bool isNearPilot;
    public bool bottle;
    public static Desert_Dialogue Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Desert_Dialogue>();
            if (_instance == null)
            {
                GameObject container = new GameObject("DialogManager");
                _instance = container.AddComponent<Desert_Dialogue>();
            }

            return _instance;
        }
    }
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => dialogs[0].UpdateDialog());

        Snake.SnakeMovingBtn();
        yield return new WaitForSeconds(5);
        yield return new WaitUntil(() => Snake.isMoving == false);
        yield return new WaitUntil(() => dialogs[1].UpdateDialog());
        
        yield return new WaitUntil(() => GameManager.Instance.Pilot == true);
        yield return new WaitUntil(() => dialogs[2].UpdateDialog());

        yield return new WaitUntil(() => isNearPilot == true);
        yield return new WaitUntil(() => dialogs[3].UpdateDialog());
        
        yield return new WaitUntil(() => bottle == true);
        yield return new WaitUntil(() => dialogs[4].UpdateDialog());
        
        RewardUI.SetActive(true);
        yield return new WaitUntil(() => (PlayerPrefs.GetString("Desert_Reward") != ""));
        yield return new WaitUntil(() => dialogs[5].UpdateDialog());
        
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Confidence(0.5f);

        SceneLoader loader = GetComponent<SceneLoader>();
        loader.LoadScene("UniverseDesertToEarth");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
