using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Start_Dialogue : MonoBehaviour
{

    [SerializeField] private DialogueSystem[] dialogs;
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private GameObject unicornLocation;
    private static Earth_Start_Dialogue _instance;

    public static Earth_Start_Dialogue Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Earth_Start_Dialogue>();
            if (_instance == null)
            {
                GameObject container = new GameObject("DialogManager");
                _instance = container.AddComponent<Earth_Start_Dialogue>();
            }
            return _instance;
        }
    }
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => dialogs[0].UpdateDialog());
        
        //yield return new WaitUntil(()=>unicornLocation.detected)
        yield return new WaitUntil(() =>  dialogs[1].UpdateDialog());
        tutorialUI.SetActive(true);
    }
}
