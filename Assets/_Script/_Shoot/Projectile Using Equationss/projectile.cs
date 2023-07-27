using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {


    public Rigidbody objectLaunched;
    public GameObject cursor;
    public LayerMask layer;
    public Transform shootPoint;
    private Camera cam;
    Vector3 newVel;

	// Use this for initialization
	void Start () {

        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // LauncheProjcetile();

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody obj = Instantiate(objectLaunched, shootPoint.position, Quaternion.identity);

            obj.velocity = new Vector3(projectileVelocity().x , projectileVelocity().y , projectileVelocity().z);
        }



    }

    void LauncheProjcetile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, 1f);
            transform.rotation = Quaternion.LookRotation(Vo);

           // if(Input.GetMouseButtonDown(0))
           // {
             //   Rigidbody obj = Instantiate(objectLaunched, shootPoint.position, Quaternion.identity);


              //  obj.velocity = new Vector3(Vo.x, Vo.y, Vo.z);
         //   }


        }
        else
        {
            cursor.SetActive(false);
        }




    }


    Vector3 projectileVelocity()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 Vo = Vector3.zero;

        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vo = CalculateVelocity(hit.point, shootPoint.position, 10f);
            transform.rotation = Quaternion.LookRotation(Vo);

            return Vo;

        }
        else
        {
            cursor.SetActive(false);
        }


        return Vo;




    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        // define the distance x and y first
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        // distance value
        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / 1f;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;

    }
}
