using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {


    public Health health;

    public void AddHearts()
    {
        health.AddHearts(1);
    }

    public void ModifyHearts()
    {
        health.Modifyhealth(-5);
    }

    public void AddHealth()
    {
        health.Modifyhealth(5);
    }

    public void addLargerHealth()
    {
        health.Modifyhealth(20);
    } 
}



//private void Update()
//{
//    if (Input.GetKeyDown(KeyCode.Y))
//    {
//        health.AddHearts(1);
//    }
//    if (Input.GetKeyDown(KeyCode.U))
//    {
//        health.Modifyhealth(-5);
//    }
//    if (Input.GetKeyDown(KeyCode.I))
//    {
//        health.Modifyhealth(5);
//    }

//}


