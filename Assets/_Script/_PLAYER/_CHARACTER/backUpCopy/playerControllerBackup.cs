using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerBackup : MonoBehaviour {


    public Transform origin;


    [System.Serializable]
    public class MoveSettings
    {
        public float forwardVel = 12;
        public float rotateVel = 100;
        public float jumpVel = 25;
        public float distToGround = 0.5f;
        public LayerMask ground;
    }

    [System.Serializable]
    public class PhysicsSettings
    {
       public float downAccel = 0.5f;
    }

    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }




    // Use this for initialization
    Vector3 velocity = Vector3.zero;
    public MoveSettings moveSettings = new MoveSettings();
    public PhysicsSettings physicsSettings = new PhysicsSettings();
    public InputSettings inputSettings = new InputSettings();
    
    
    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSettings.distToGround, moveSettings.ground);
    }

   public bool getGrounded()
   {

        return Grounded();

   }


    Quaternion targetRotation;
    Rigidbody rigidbody;
    ///float forwardInput, turnInput, jumpInput;
    bool jump = false;


    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }


    private void Start()
    {
       /// targetRotation = transform.rotation;   // i will not require this, later i will delete it
        rigidbody = GetComponent<Rigidbody>();


        ////forwardInput = turnInput = jumpInput = 0;
    }

    private void Update()
    {

       /// GetInput();
       // Turn();
       // Debug.Log(Grounded());
       
    }

    private void FixedUpdate()
    {
       // Run();
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
