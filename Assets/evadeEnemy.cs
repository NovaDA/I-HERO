using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class evadeEnemy : MonoBehaviour {

    private NavMeshAgent _Agent;

    public GameObject chaser;

    public float EvadeDistanceRun = 4.0f;
	// Use this for initialization
	void Start () {

        _Agent = GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(transform.position, chaser.transform.position);


        if(distance < EvadeDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - chaser.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;


            _Agent.SetDestination(newPos);
        }
		
	}
}
