using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot_Detect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Light;

    private bool isPilot;
    //public GameObject dialogue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isPilot = GameManager.Instance.Pilot;

        if (isPilot)
        {
            Light.SetActive(true);
            Debug.Log("Light On");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Desert_Dialogue.Instance.isNearPilot = true;
        }
    }
}
