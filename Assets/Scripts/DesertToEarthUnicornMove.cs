
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DesertToEarthUnicornMove : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    //[SerializeField]
    public Transform target;

    void Start ()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.SetDestination (target.position);	
    }

    void Update ()
    {
        navMeshAgent.SetDestination (target.position); 
    }

    private void OnTriggerEnter()
    {
	    SceneManager.LoadScene("Earth_plane");//보상씬 이름으로 바꾸기
    }
}
