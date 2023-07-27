using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    // Use this for initialization
    float speed = 0.1f;
    float currentRotation = 0;    //Rotation of The camera
    float targetRotation = 100;
    private float nextRor = 180;
    float resetRotation = 0;

    /// Variables to trigger the rotation
    bool rotateCam = false; 
    public Transform position;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(rotateCam == true)
        {
            if (currentRotation != targetRotation)
            {
                transform.RotateAround(position.position, Vector3.up, 1f);
                currentRotation += 1;
            }
            else
            {
                rotateCam = false;
                targetRotation = nextRor;                                    /// Plannig to change it to sequence of rotations
            }
        }
    }
    public void TriggerRotation()
    {
        rotateCam = true;
    }

    public void ResetRotationOfCamera()
    {
        currentRotation = resetRotation;                                        // make the camera back to its orignal rotation in case the camera position changes
    }
}
