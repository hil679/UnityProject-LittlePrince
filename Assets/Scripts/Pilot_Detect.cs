using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot_Detect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Manager;
    public GameObject Light;

    private bool isPilot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isPilot = Manager.GetComponent<GameManager>().Pilot;

        if (isPilot)
        {
            Light.SetActive(true);
            Debug.Log("Light On");
        }
    }
}
