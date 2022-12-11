using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desert_Dialogue : MonoBehaviour
{
    [SerializeField] private DialogueSystem[] dialogs;

    [SerializeField] private GameObject RewardUI;
    
    private static Desert_Dialogue _instance;

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

        yield return new WaitUntil(() => dialogs[1].UpdateDialog());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
