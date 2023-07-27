using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    public float vel = 5;
    public float turnSpeed = 10;

    Vector2 input;
    float angle;

    Quaternion targetRot;
    Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void Update()
    {
        getInput();

        if(Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1 ) return;
    }

    private void getInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    private void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);   /// Get Radians
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }

    private void Rotate()
    {
        targetRot = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        transform.position += transform.forward * vel * Time.deltaTime;
    }

    

    

   
}

