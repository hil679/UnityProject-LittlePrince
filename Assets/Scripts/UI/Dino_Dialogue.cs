using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino_Dialogue : MonoBehaviour
{

    [SerializeField] private DialogueSystem dialog1;
    [SerializeField] private GameObject StarGen;
    [SerializeField] private DialogueSystem dialog2;

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
        yield return new WaitUntil(() => dialog1.UpdateDialog());
        //첫 대화 끝난 후 운석 생성기 작동
        StarGen.SetActive(true);

        yield return new WaitUntil(() => Dinosaur_UImanager.Instance.Successed);
        
        yield return new WaitForSeconds(1);
        //성공 후 다이얼로그 업데이트, 자신감 수치 증가
        yield return new WaitUntil(() => dialog2.UpdateDialog());
        GameManager.Instance.Confidence(0.5f);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
