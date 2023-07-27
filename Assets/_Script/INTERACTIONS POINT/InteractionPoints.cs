using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPoints : MonoBehaviour {

    static GameObject headPoint;
    static GameObject tailPoint;

    private void Awake()
    {
        headPoint = GameObject.Find("stun");
        tailPoint = GameObject.Find("tail");
    }

    public static Vector3 Headposition()
    {
        return headPoint.transform.position;
    }

    public static Vector3 Tailposition()
    {
        return tailPoint.transform.position;
    }


}
