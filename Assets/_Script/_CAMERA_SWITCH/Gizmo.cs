using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour {

    float areaSize = 20;
    public float areaOffset;
    public string typeGizmo;
    // Use this for initialization
    private void OnDrawGizmos()
    {
        Vector3 spawnArea = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(spawnArea, areaSize);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
