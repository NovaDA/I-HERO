using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationsController : MonoBehaviour {

    Animator animator;   
    bool Idle;
    bool Attack;
    bool Move;
    bool Die;

    /// Now specifically used for hero character
    bool Jump;
    bool Victory;
	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
		
	}

    public bool SetIdle
    {
        get { return Idle; }
        set { Idle = value; }
    }

    public bool SetDie
    {
        get { return Die; }
        set { Die = value; }
    }

    public bool SetAttack
    {
        get { return Attack; }
        set { Attack = value; }
    }

    public bool SetMove
    {
        get { return Move; }
        set { Move = value; }
    }

    public bool SetJump
    {
        get { return Jump; }
        set { Jump = value; }
    }

    public bool SetVictory
    {
        get { return Victory; }
        set { Victory = value; }
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public void TriggerStun()
    {
        animator.SetTrigger("Stun");
    }

    public void TriggerAttack()
    {
        animator.SetTrigger("Attack1");
    }

    public void TriggerJump()
    {
        animator.SetTrigger("Jump");
    }

    public void TriggerDamage()
    {
        animator.SetTrigger("Damage");
    }

    // Update is called once per frame
    void Update () {

        if (Idle)                                // Idle Status not used at the moment
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }

        if (Attack)
        {
            animator.SetBool("Attack", true);
            Attack = !Attack;

        }
        else
        {
            animator.SetBool("Attack", false);
        }

        if(Move)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

        if (Die)
        {
            animator.SetBool("Die", true);
        }
        else
        {
            animator.SetBool("Die", false);
        }

        if (Jump)
        {
            animator.SetBool("jUMP", true);
        }
        else
        {
            animator.SetBool("JUMP", false);
        }

        if (Victory)
        {
            animator.SetBool("Victory", true);
        }
        else
        {
            animator.SetBool("Victory", false);
        }
    }

    ///  Remove Those at the end as it will be manually acessed

    #region
    private void CheckInput()
    {
        if(gameObject.name == "Musketeer_prefab")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack = !Attack;

            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                Move = !Move;

            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                TriggerStun();

            }
        }

    }
    #endregion
}


//CheckInput();  // DELETE

// bool Stun;
#region
//if(animator.GetCurrentAnimatorStateInfo(0).IsName("Bat_Idle"))
// {
//     
// }
//else if(animator.GetCurrentAnimatorStateInfo(0).IsName("Bat_Move"))
// {
//     if(Input.GetKeyDown(KeyCode.Space))
//     {
//         
//     }
// }

//if (Input.GetKeyDown(KeyCode.D))
//{
//   
//}
#endregion
