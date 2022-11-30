using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTest : MonoBehaviour
{
    [SerializeField]
    private DialogueSystem dialogSystem;

    [SerializeField] 
    private TextMeshProUGUI textCountdown;

    [SerializeField] private DialogueSystem dialogSystem2;

    private IEnumerator Start()
    {
        textCountdown.gameObject.SetActive(false);
        
        yield return new WaitUntil(()=>dialogSystem.UpdateDialog());
        
        textCountdown.gameObject.SetActive(true);
        int count = 5;
        while (count > 0)
        {
            textCountdown.text = count.ToString();
            count--;

            yield return new WaitForSeconds(1);
        }
        textCountdown.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
