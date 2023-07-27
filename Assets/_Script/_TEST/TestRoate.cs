using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoate : MonoBehaviour {

    /// <summary>
    /// Transforms later to be be got using code
    Transform center;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public Transform interesterdPos;
    public float radius;          /// Need To Setup a radius 
    public float radiusSpeed = 1.5f;
    public float rotationSpeed = 80.0f;

    /// 
    bool canRotate = true;

    void Start()
    {
        GetChildrenOfParent();
        CalculateRadius();
        transform.position = (transform.position - center.position).normalized * radius + center.position;
    }

    private void GetChildrenOfParent()
    {
        Transform parent = transform.root;                // Get the highest parent in the hierarchy
        Transform[] children = parent.gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if(child.gameObject.name == "OriginRot")
            {
                //Debug.Log(child.gameObject.name);
                center = child.gameObject.transform;
            } 
        }
    }

    void Update()
    {
        if(canRotate)
        {
            transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
            desiredPosition = (transform.position - center.position).normalized * radius + center.position;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        }
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Enemy")
    //    {
    //        //other.transform.rotation = this.transform.rotation;
    //       // other.gameObject.transform.parent = this.transform;
    //        EnableRotation();
    //        if (other.transform.position == this.transform.position)
    //        {
                
    //        }
            
    //       // Invoke("EnableRotation", 0.1f);
    //    }
    //}


    private void EnableRotation()
    {
        canRotate = true;
    }

    private void CalculateRadius()
    {
        //radius = ( origin.position - transform.position).sqrMagnitude;
        radius = Vector3.Distance(center.position, transform.position);
        
    }
}
