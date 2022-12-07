
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnicornMove : MonoBehaviour
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
	
	
}
