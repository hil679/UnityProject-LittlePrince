using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Detected : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Water")
		{
            Debug.Log("Water");
            GameManager.Instance.Pilot = true;
            //Debug.Log(PilotManager.GetComponent<GameManager>().Pilot);
            GameObject tutorialUI = GameObject.Find("WaterInterUI");
            tutorialUI.SetActive(false);
		}
	}
}
