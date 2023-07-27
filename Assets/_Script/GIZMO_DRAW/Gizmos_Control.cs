using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmos_Control : MonoBehaviour {



    public bool isGizmoVisible = false;

    [Range(0, 100)]
    public float Range;
    public Vector3 size;

    private void OnDrawGizmos()
    {
        if (!isGizmoVisible)
            return;

        if(gameObject.tag == "Local")
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Range);
        }
        else if(gameObject.tag == "Camera Switch")
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Range);
        }
        else if (gameObject.name == "Enemy_Spawn01" || 
            gameObject.name == "Enemy_Spawn02" || gameObject.name == "Enemy_Spawn03")
        {
            Gizmos.color = Color.cyan;
           // Gizmos.DrawWireSphere(transform.position, Range);
            Gizmos.DrawWireCube(transform.position, size);
        }
        else if(gameObject.name == "Pivot")
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, size);
        }
        else if (gameObject.name == "RotatePos" || gameObject.name == "RotationPos" || gameObject.name == "OriginRot" )
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, size);
        }
        else if (gameObject.name == "PivotBoss")
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, size);
        }
        else if(gameObject.name == "Enemy_Rush")
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
        else if(gameObject.tag == "Waypoint")
        {
            Gizmos.color = Color.yellow;
            //Gizmos.DrawCube(transform.position, size);
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
        else if(gameObject.tag == "SingleEnemy")
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, 0.5f);

        }
        else if (gameObject.tag == "escapeZone1")
        {
            Gizmos.color = Color.black;
            Gizmos.DrawCube(transform.position, size);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, size);
        }
        
        


    }

}
