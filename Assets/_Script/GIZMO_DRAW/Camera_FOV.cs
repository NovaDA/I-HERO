using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FOV : MonoBehaviour {

    // Use this for initialization
    private void OnDrawGizmos()
    {

        /// Used to set up the field of view of cameras to help more with preview of camera view
        float totalFOV = 70.0f;
        float rayRange = 10.0f;
        float halfFOV = totalFOV / 2.0f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, leftRayDirection * rayRange);
        Gizmos.DrawRay(transform.position, rightRayDirection * rayRange);

    }

}
