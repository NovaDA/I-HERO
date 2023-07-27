using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    // Used to spawn reward for some destroyed objects
    Vector3 spawnPosition;
    public GameObject Collectable;

	void Start () {
        spawnPosition = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
	}
	
    public void destroyGameObject()
    {

        if(gameObject.name == "Box")
        {
            Instantiate(Collectable, spawnPosition, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            
        }


    }

}
