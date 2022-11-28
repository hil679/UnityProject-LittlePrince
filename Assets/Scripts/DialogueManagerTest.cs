using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManagerTest : MonoBehaviour
{
    public Text dialogueText;
    public GameObject NextText;
    public CanvasGroup UICanvas_DialogueGroup;
    public Queue<string> sentences;
    public Queue<AudioSource> Audios;
    private string currentSentence;

    public float TypeSpeed = 0.1f;

    private bool isTyping = true;

    public static DialogueManagerTest instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void Ondialogue(string[] lines, AudioSource[] audios)
    {
        sentences.Clear();
        foreach(string line in lines)
        {
            sentences.Enqueue(line);
        }
        UICanvas_DialogueGroup.alpha = 1;
        UICanvas_DialogueGroup.blocksRaycasts = true;
        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();
            isTyping = true;
            NextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
        }
        else
        {
            UICanvas_DialogueGroup.alpha = 0;
            UICanvas_DialogueGroup.blocksRaycasts = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText.text.Equals(currentSentence))
        {
            NextText.SetActive(true);
            isTyping = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextSentenceBtn();
        }
    }

    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach(char letter in line.ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(TypeSpeed);
        }
    }

    public void NextSentenceBtn()
    {
        Debug.Log("Next Btn pressed");
        if (!isTyping)
            NextSentence();
    }
}
