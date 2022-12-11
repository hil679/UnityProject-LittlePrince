using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player") // && 공룡별 NPC일 경우 넣기
        {

            Debug.Log("Teleporting");
        }
        
    }
}
