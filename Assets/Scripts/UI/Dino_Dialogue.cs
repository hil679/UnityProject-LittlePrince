using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino_Dialogue : MonoBehaviour
{

    [SerializeField] private DialogueSystem[] dialog;
    [SerializeField] private GameObject StarGen;
    [SerializeField] private GameObject RewardUI;
    private static Dino_Dialogue _instance;

    public static Dino_Dialogue Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Dino_Dialogue>();
            if (_instance == null)
            {
                GameObject container = new GameObject("DialogManager");
                _instance = container.AddComponent<Dino_Dialogue>();
            }

            return _instance;
        }
    }

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        //씬 입장 대사 출력
        yield return new WaitUntil(() => dialog[0].UpdateDialog());
        //첫 대화 끝난 후 운석 생성기 작동
        StarGen.SetActive(true);

        yield return new WaitUntil(() => Dinosaur_UImanager.Instance.Successed);
        
        StarGen.SetActive(false);
        yield return new WaitForSeconds(1);
        //성공 후 다이얼로그 진행
        yield return new WaitUntil(() => dialog[1].UpdateDialog());
        //보상 선택
        RewardUI.SetActive(true);
        yield return new WaitUntil(() => (PlayerPrefs.GetString("Dino_Reward") != ""));
        yield return new WaitUntil(() => dialog[2].UpdateDialog());
        
        //대화 끝난 후 자신감 상승, 이동 튜토리얼 진행
        yield return new WaitForSeconds(2f);
        GameManager.Instance.Confidence(0.5f);
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
