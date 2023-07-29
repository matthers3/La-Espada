using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum WorldState
    {
        Grounded, //on ground
        InAir, //in the air
    }

    [SerializeField] private RaySelector raySelector;

    [HideInInspector]
    public WorldState States;
    private Transform Cam;
    private Transform CamY;
    //public ControlsPivot AxisPivot;
    private CameraFollow CamFol;

    private DetectCollision Colli;
    [HideInInspector]
    public Rigidbody Rigid;

    float delta;

    [Header("Physics")]
    public Transform[] GroundChecks;
    public float DownwardPush; //what is applied to the player when on a surface to stick to it
    public float GravityAmt;    //how much we are pulled downwards when we are on a wall
    public float GravityBuildSpeed; //how quickly we build our gravity speed
    private float ActGravAmt; //the actual gravity applied to our character

    public LayerMask GroundLayers; //what layers the ground can be
    public float GravityRotationSpeed = 10f; //how fast we rotate to a new gravity direction

    [Header("Stats")]
    public float Speed = 15f; //max speed for basic movement
    public float Acceleration = 4f; //how quickly we build speed
    public float turnSpeed = 2f;
    private Vector3 MovDirection, movepos, targetDir, GroundDir; //where to move to

    // Start is called before the first frame update
    void Awake()
    {
        Rigid = GetComponentInChildren<Rigidbody>();
        Colli = GetComponent<DetectCollision>();
        GroundDir = transform.up;
        SetGrounded();

        //detatch rigidbody so it can move freely 
        Rigid.transform.parent = null;
    }

    private void Update()   //inputs
    {
        transform.position = Rigid.position;
    }

    // Update is called once per frame
    void FixedUpdate()  //world movement
    {
        delta = Time.deltaTime;

        if (raySelector.inspecting == true) {
            return;
        }

        float Spd = Speed;

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            //we are not moving, lerp to a walk speed
            Spd = 0f;
        }
        
        
        MoveSelf(delta, Spd, Acceleration);

        //switch to air
        bool Ground = Colli.CheckGround(-GroundDir);

        if (!Ground)
        {
            SetInAir();
            return;
        }
    }

    //transition to ground
    public void SetGrounded()
    {
        ActGravAmt = 5f; //our gravity is returned to normal
        States = WorldState.Grounded;
    }
    //transition to air
    void SetInAir()
    {
        States = WorldState.InAir;
    }
 
    //check the angle of the floor we are stood on
    Vector3 FloorAngleCheck()
    {
        RaycastHit HitFront;
        RaycastHit HitCentre;
        RaycastHit HitBack;

        Physics.Raycast(GroundChecks[0].position, -GroundChecks[0].transform.up, out HitFront, 10f, GroundLayers);
        Physics.Raycast(GroundChecks[1].position, -GroundChecks[1].transform.up, out HitCentre, 10f, GroundLayers);
        Physics.Raycast(GroundChecks[2].position, -GroundChecks[2].transform.up, out HitBack, 10f, GroundLayers);

        Vector3 HitDir = transform.up;

        if (HitFront.transform != null)
        {
            HitDir += HitFront.normal;
        }
        if (HitCentre.transform != null)
        {
            HitDir += HitCentre.normal;
        }
        if (HitBack.transform != null)
        {
            HitDir += HitBack.normal;
        }

        Debug.DrawLine(transform.position, transform.position + (HitDir.normalized * 5f), Color.red);

        return HitDir.normalized;
    }
    
    //move our character
    void MoveSelf(float d, float Speed, float Accel)
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");
        bool MoveInput = false;

        Vector3 screenMovementForward = transform.forward;
        Vector3 screenMovementRight = transform.right;

        Vector3 h = screenMovementRight * _xMov;
        Vector3 v = screenMovementForward * _zMov;

        Vector3 moveDirection = (v + h).normalized;

        if (_xMov == 0 && _zMov == 0)
        {
            Rigid.velocity = Vector3.zero;
            Rigid.angularVelocity = Vector3.zero; 
            return;
        }
        else
        {
            targetDir = moveDirection;
            MoveInput = true;
        }

        if (targetDir == Vector3.zero)
        {
            targetDir = transform.forward;
        }

        float TurnSpd = turnSpeed;

        Vector3 SetGroundDir = FloorAngleCheck();
        GroundDir = SetGroundDir;

        //lerp mesh slower when not on ground
        RotateSelf(SetGroundDir, d, GravityRotationSpeed);

        //move character
        float Spd = Speed;
        Vector3 curVelocity = Rigid.velocity;

        if (!MoveInput) //if we are not pressing a move input we move towards velocity //or are crouching
        {
            MovDirection = new Vector3(0, 0, 0);
        }
        else
        {
            MovDirection = targetDir;
        }

        Vector3 targetVelocity = MovDirection * Spd;

        //push downwards in downward direction of mesh
        targetVelocity -= SetGroundDir * DownwardPush;

        Vector3 dir = targetVelocity;
        Rigid.velocity = dir;
    }

    //rotate the direction we face down
    void RotateSelf(Vector3 Direction, float d, float GravitySpd)
    {
        Vector3 LerpDir = Vector3.Lerp(transform.up, Direction,  Time.deltaTime * GravitySpd);
        transform.rotation = Quaternion.FromToRotation(transform.up, LerpDir) * transform.rotation;
    }
}
