using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Trigger_Manager : MonoBehaviour
{
    public string[] Dino_sentences;
    public AudioSource[] Dino_audioSources;
    public GameObject NPC_Dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Player") // && 공룡별 NPC일 경우 넣기
        {
            if(NPC_Dialogue != null)
            {
                NPC_Dialogue.SetActive(true);
            }
            //Debug.Log($"Player entered to the NPC Area of ${this.name}");
        }
        if(DialogueManagerTest.instance.UICanvas_DialogueGroup.alpha == 0)
            DialogueManagerTest.instance.Ondialogue(Dino_sentences, Dino_audioSources);
    }
    private void OnTriggerExit(Collider other)
    {
        if (NPC_Dialogue != null)
        {
            NPC_Dialogue.SetActive(false);
        }
    }
}
