using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using BNG;
using UnityEngine.Audio;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private int branch;
    [SerializeField] private Dialog_script dialogScript;
    [SerializeField] private Speaker[] speakers;
    [SerializeField] private DialogData[] Dialogs;
    [SerializeField] private bool isAutoStart = true;
    [SerializeField] private AudioClip[] TTSs;
    [SerializeField] private AudioMixerGroup MixerName;

    [SerializeField] private bool isFirst = false;
    private int currentDialogIndex = -1;
    private int currentSpeakerIndex = 0;
    
    [SerializeField]
    private float typingSpeed = 0.1f;
    private bool isTypingEffect = false;
    // Start is called before the first frame update
    private void Awake()
    {
        int index = 0;
        for (int i = 0; i < dialogScript.Dino.Count; ++i)
        {
            if (dialogScript.Dino[i].branch == branch)
            {
                Dialogs[index].name = dialogScript.Dino[i].name;
                Dialogs[index].dialogue = dialogScript.Dino[i].Dialog;
                index++;
            }
        }
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < speakers.Length; i++)
        {
            SetActiveObjects(speakers[i], false);
            
            speakers[i].characterImage.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    public bool UpdateDialog()
    {
        if (isFirst == true)
        {
            Setup();

            if (isAutoStart) SetNextDialog();

            isFirst = false;
        }

        if (InputBridge.Instance.RightTriggerDown)
        {
            if (isTypingEffect == true)
            {
                isTypingEffect = false;
                
                StopCoroutine("OnTypingText");
                speakers[currentSpeakerIndex].textDialogue.text = Dialogs[currentDialogIndex].dialogue;
                speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                return false;
            }
            if (Dialogs.Length > currentDialogIndex + 1)
            {
                SetNextDialog();
            }
            else
            {
                for (int i = 0; i < speakers.Length; i++)
                {
                    SetActiveObjects(speakers[i], false);
                    speakers[i].characterImage.gameObject.SetActive(false);
                }

                return true;
            }
        }

        return false;
    }

    private void SetNextDialog()
    {
        SetActiveObjects(speakers[currentSpeakerIndex], false);
        currentDialogIndex++;
        currentSpeakerIndex = Dialogs[currentDialogIndex].speakerIndex;
        SetActiveObjects(speakers[currentSpeakerIndex], true);
        speakers[currentSpeakerIndex].textName.text = Dialogs[currentDialogIndex].name;
        speakers[currentSpeakerIndex].textDialogue.text = Dialogs[currentDialogIndex].dialogue;
        StartCoroutine("OnTypingText");
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageDialogue.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);
        
        speaker.objectArrow.SetActive(false);

        Color color = speaker.characterImage.color;
        color.a = visible == true ? 1 : 0.2f;
        speaker.characterImage.color = color;
    }
    
    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;
        VRUtils.Instance.PlaySpatialClipAt(TTSs[currentDialogIndex], transform.position, 1.0f, 1.0f, 0, MixerName);
        while (index <= Dialogs[currentDialogIndex].dialogue.Length)
        {
            speakers[currentSpeakerIndex].textDialogue.text = Dialogs[currentDialogIndex].dialogue.Substring(0, index);
            index++;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;
        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
    }
}



[System.Serializable]
public struct Speaker
{
    public Image characterImage;
    public Image imageDialogue;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textDialogue;
    public GameObject objectArrow;
}

[System.Serializable]
public struct DialogData
{
    public int speakerIndex;
    public string name;
    [TextArea(3, 5)] public string dialogue;
} 