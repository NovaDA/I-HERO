using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMove : MonoBehaviour {


    int layerMask = 1 << 8;

    public float speed;
    public float fireRate;
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;

    private Transform origin;
    float distance;
    // Use this for initialization
    void Start () {
        if (muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
            var psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
            if (psMuzzle != null)
            {
                Destroy(muzzleVFX, psMuzzle.main.duration);
            }
            else
            {
                var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(muzzleVFX, psChild.main.duration);
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        if(speed != 0)
        {
            transform.position += transform.forward * (speed * (Time.deltaTime * 10));
        }
        else
        {
            //Debug.Log("No Speed");
        }


        if (origin != null)
        {
            distance = Vector3.Distance(origin.position, transform.position);
        }

        if (distance >= 200)
        {
            Destroy(gameObject);
            UIController.IncreaseMissedHits();
        }
		
	}

    public void CreateSpawnPoint(Transform spawnLocation)
    {
        origin = spawnLocation;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "IgnoreObject")
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());

        }
        else
        {
            speed = 0;

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            if (hitPrefab != null)
            {
                var hitVFX = Instantiate(hitPrefab, pos, rot);
                var psHit = hitVFX.GetComponent<ParticleSystem>();
                if (psHit != null)
                {
                    Destroy(hitVFX, psHit.main.duration);
                }
                else
                {
                    var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(hitVFX, psChild.main.duration);
                }
            }
            UIController.IncreaseHits();
            Destroy(gameObject);
        }

       
    }
}
