using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Area : MonoBehaviour {


    bool heroEnteredAttackRange;
    AnimationsController animations;
    Quaternion DestRot = Quaternion.identity;   // TRANSFERED TO aVATARcONTROLLER
    GameObject Boss;

    // Use this for initialization
    void Start () {
        
        animations = transform.root.GetComponent<AnimationsController>();
        Boss = transform.root.GetComponent<BossBehaviour>().gameObject;
    }
	
	// Update is called once per frame
	void Update () {
      }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Pivot")
        {
            animations.TriggerAttack();         /// Pay Attantion
            RotateBoss(other);
            Debug.Log("Player Entered Attack Range");
        }
    }

    private void RotateBoss(Collider other)
    {
        Vector3 targetPosition = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
        Vector3 relativePos = targetPosition - transform.position;
        DestRot = Quaternion.LookRotation(relativePos, other.transform.up);
        Boss.transform.rotation = Quaternion.RotateTowards(Boss.transform.rotation, DestRot, 0.1f);
    }
}
