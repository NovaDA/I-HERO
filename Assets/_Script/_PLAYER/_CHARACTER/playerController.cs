using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {


   /// public Transform origin;

    [System.Serializable]
    public class MoveSettings
    {
        public float jumpVel = 25;
        public float distToGround = 0.5f;
        public LayerMask ground;
    }

    [System.Serializable]
    public class PhysicsSettings
    {
       public float downAccel = 0.5f;
    }

    // Use this for initialization
    Vector3 velocity = Vector3.zero;
    public MoveSettings moveSettings = new MoveSettings();
    public PhysicsSettings physicsSettings = new PhysicsSettings();

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSettings.distToGround, moveSettings.ground);
    }

   public bool getGrounded()
   {

        return Grounded();

   }

    Rigidbody rigidbody;
    bool jump = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        Jump();                                                        /// required
        rigidbody.velocity = transform.TransformDirection(velocity);   /// required
        
    }

    public void Jump()
    {
        if(jump && Grounded())
        {
            velocity.y = moveSettings.jumpVel;
            velocity.z = 3.0f;
        }
        else if(!jump && Grounded())
        {
            velocity.y = 0;
            velocity.z = 0;
        }
        else
        {
            velocity.y -= physicsSettings.downAccel;
            velocity.z = 3.0f;
        }

        if (jump && velocity.y > 0)
        {
            jump = false;
        }   
    }

    public void triggerJump()
    {
        jump = true;
       
    }

  
}





#region useless code
// void Run()
// {
//if(Mathf.Abs(forwardInput) > inputSettings.inputDelay)
//{
//    // move
//    velocity.z = moveSettings.forwardVel * forwardInput;
//}
//else
//{
//    velocity.z = 0;
//}
// }

//void Turn()
//{
//    targetRotation *= Quaternion.AngleAxis(moveSettings.rotateVel * turnInput * Time.deltaTime, Vector3.up);
//    transform.rotation = TargetRotation;
//}


/// void GetInput()
///  {
///      forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS);
///      turnInput = Input.GetAxis(inputSettings.TURN_AXIS);
///      jumpInput = Input.GetAxisRaw(inputSettings.JUMP_AXIS);
///  }

#endregion
