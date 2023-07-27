using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{    
    Transform BossPosition;
    /// health
    HealthController BossHealthController;
    Health BossHealth;

    /// Attack Condition
    float ElapsedTime;
    float WakeUpTime = 3.0f;
    bool FightOn;
    /// Move Conditions
    /// 
    private int index = 1;
    public float Speed;
    int PreviousIndex;
    List<Transform> ListWayPoints = new List<Transform>();


    /// Animation Controller
    Animator AnimationController;
    AnimationsController Animations;

    Quaternion DestRot = Quaternion.identity;

    // Use this for initialization
    void Start()
    {
        AddPositionsToList();
        BossHealth = GetComponentInChildren<Health>();
        BossHealthController = GetComponentInChildren<HealthController>();
        BossPosition = GetComponent<Transform>();
        AnimationController = GetComponent<Animator>();
        Animations = GetComponent<AnimationsController>();
        FightOn = false;
    }

    private void AddPositionsToList()
    {
        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            ListWayPoints.Add((waypoint).transform);
        }
        var newList = ListWayPoints.OrderBy(x => x.name).ToList();
        ListWayPoints = (List<Transform>)newList;
    }

    public Transform GetCoordinateWaypoint()         // used only for the pivotPoint
    {
        return ListWayPoints[index];                    // In this instance i am trying to return 
    }                                                   // the position of the target waypoint as i need to extract the Y position

    public void DamageBoss()
    {
        if(FightOn)
        {
            Animations.TriggerDamage();
            BossHealthController.ModifyHearts();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!FightOn && BossHealth.GetHealth() > 0)
        {
            ElapsedTime += Time.deltaTime;
            if(ElapsedTime > WakeUpTime)
            {    
                FightOn = true;
                Animations.SetMove = true;
            }
        }

        if(BossHealth.GetHealth() <= 0)
        {
            FightOn = false;
            Animations.TriggerStun();
            Animations.SetDie = true;   
        }

        if(!AnimationController.GetCurrentAnimatorStateInfo(0).IsName("idle") &&
            !AnimationController.GetCurrentAnimatorStateInfo(0).IsName("attack_1") && FightOn)
        {
            Move();
        }

        if(AnimationController.GetCurrentAnimatorStateInfo(0).IsName("death"))
        {
            Invoke("GameWonScreen", 2);
        }
    }

    private void GameWonScreen()
    {
        GameLevelManager.LoadNextLevel();
    }


    #region BOSS MOVEMENT

    private void Move()
    {

        Vector3 targetPosition = new Vector3(ListWayPoints[index].position.x, BossPosition.position.y, ListWayPoints[index].position.z);
        Vector3 relativePos = targetPosition - BossPosition.position;
        DestRot = Quaternion.LookRotation(relativePos, ListWayPoints[index].up);

        BossPosition.rotation = Quaternion.RotateTowards(BossPosition.rotation, DestRot, 1);
        MoveTowardsTheTarget(ListWayPoints[index]);
    }

    void MoveTowardsTheTarget(Transform nextPosition)   // move character toward next position
    {

        Vector3 targetPos = new Vector3(nextPosition.position.x, BossPosition.position.y, nextPosition.position.z);      /// trying to ignore the Y position
        BossPosition.position = Vector3.MoveTowards(BossPosition.position, targetPos, Speed * Time.deltaTime);

    }


    public void ChangetIndex()   // RENAME IT INDEX
    {
        index = GetNewIndex();
    }

    private int GetNewIndex()
    {
        int newIndex;
        do
        {
            newIndex = UnityEngine.Random.Range(0, ListWayPoints.Count);

        } while (newIndex == PreviousIndex);
        PreviousIndex = newIndex;
        return newIndex;
    }

    #endregion

}
