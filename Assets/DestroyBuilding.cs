using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuilding : MonoBehaviour {


    int children = 0;
    List<GameObject> BuildingComponents = new List<GameObject>();
	// Use this for initialization
	void Start () {
        getChildrenCounts();
        StartCoroutine(CheckChildren()); 	
	}

    IEnumerator CheckChildren()
    {
        while (true)
        {
           // Debug.Log(children);
            getChildrenCounts();
            yield return new WaitForSeconds(2.0f);  /// Spawn wait      
        }
    }


    private void getChildrenCounts()
    {
        children = transform.childCount;
        if(transform.childCount <= 0)
        {
           // Debug.Log("You Erned 1000 points");
            //FindObjectOfType<UIController>().IncreaseScoreBonus(1000);
            ///GetComponentInParent<ScoreMark>().hitNowBonus(1000);
            Destroy(gameObject,2);
        }
    }
 
}
