using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnP : MonoBehaviour {


    public GameObject firepoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse rotateToMouse;
    private GameObject effectTospawn;
    private float timeToFire = 0.5f;

	// Use this for initialization
	void Start () {
        effectTospawn = vfx[0];
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectTospawn.GetComponent<projectileMove>().fireRate;
            SpawnVFX();
        }
		
	}

    private void SpawnVFX()
    {
        GameObject vfx;

        if(firepoint != null)
        {
            vfx = Instantiate(effectTospawn, firepoint.transform.position, Quaternion.identity);
            if(rotateToMouse != null)
            {
                vfx.transform.localRotation = rotateToMouse.getRotation();
            }
        }
        else
        {
            Debug.Log("not spawn positions");
        }
    }

}
