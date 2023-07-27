using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour {

    string enemyType;  // specify type of enemy
    Collider[] colliders;
    float areaSize = 20;
    int layerMask = 1 << 10;      // working  for specific layer

    // Use this for initialization
    void Start () {
        DetectEnemyType();
        AssignEnemiesToSpawners();
    }

    private void DetectEnemyType()
    {
        /// assign the type of the enemy from the name of the control area
        enemyType = gameObject.name;
        
    }

    private void AssignEnemiesToSpawners()
    {

        colliders = Physics.OverlapSphere(transform.position, areaSize, layerMask);

        for ( int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Spawn Enemy")
            {
                colliders[i].gameObject.name = enemyType;
            }
        }
    }

    //// to be delted at the end
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, areaSize);
    }

}
