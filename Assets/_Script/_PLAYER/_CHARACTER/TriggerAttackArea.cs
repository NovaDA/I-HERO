using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttackArea : MonoBehaviour {

    SphereCollider collider;
    HealthController avatarHealth;
    public AnimationsController Animations_Controller;
    bool UnderAttack;
    bool enemyPresent;
    Collider[] colliders; // used to check if enemies are still inside
    int layerMask = 1 << 8; // working for specific layer

    private void Awake()
    {
        avatarHealth = GameObject.Find("HealthUI").GetComponent<HealthController>();
        collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            avatarHealth.ModifyHearts();
            UnderAttack = true;
            Animations_Controller.SetMove = false;
           // Debug.Log("Enemy In");
            Animations_Controller.SetIdle= true;
        }

        if(other.gameObject.name == "Collect" || other.gameObject.name == "Collect(Clone)")
        {
            avatarHealth.AddHealth();
            Destroy(other.gameObject);
        }
        if(other.gameObject.name == "Heart" || other.gameObject.name == "Heart(Clone)")
        {
            avatarHealth.AddHearts();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            UnderAttack = false;
            //Animations_Controller.SetMove = true;
           // Debug.Log("Enemy Out");
        }
    }

    public void CheckIfCollidingWithEnemies()
    {
        StartCoroutine(CheckForEnemies());
    }

    IEnumerator CheckForEnemies()
    {
        while (true)
        {

            colliders = Physics.OverlapSphere(transform.position, 1.0f, layerMask);
            for (int i = 0; i < colliders.Length; i++)
            {
               
                if (colliders[i].gameObject.tag == "Enemy")
                {
                    
                    enemyPresent = true;
                }
                else
                { 
                    enemyPresent = false;
                    UnderAttack = false;
                    if(!Animations_Controller.SetMove)
                    {
                        Animations_Controller.SetMove = true;
                    }
                    
                    yield break;
                }
                //if (!enemyPresent)
                //{
                //    yield break;
                //}
            }
            yield return new WaitForSeconds(1.0f);  /// Spawn wait      
        }
    }

    public bool GetAttackAreaState()
    {
        //Debug.Log(UnderAttack);
        return UnderAttack;
    }
    
}
