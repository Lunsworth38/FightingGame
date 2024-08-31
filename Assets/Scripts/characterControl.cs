using UnityEngine;
using UnityEngine.Animations.Rigging;

public class characterControl : Core
{
    public bool disableControl = false;

    public bool grounded;

    public Transform playerTransform;

    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    public float xInput;

    public bool hasRangedWeapon = false;
    public GameObject aimingRig;
    public Rig rig;

    public State idleState;
    public State runningState;
    public Airborne airborneState;
    public PunchingState punchingState;
    public RunningPistolState runningPistolState;
    public IdlePistolState idlePistolState;
    public HitState hitState;
    public GroundedState groundedState;
    public HasRangedWeaponState hasRangedWeaponState;
    public SecondPunchState secondPunchState;
    public ThirdPunchState thirdPunchState;
    public ChargedKickState chargedKickState;
    public AirbornePistolState airbornePistolState;
    public HasRangedWeaponAirborneState hasRangedWeaponAirborneState;

    public DeadState deadState;
    public State stateForDebug;

    public HealthControl healthControl;

    float knockbackForce;

    string playerLabel;

    public bool hit;

    float hitStopEnd;

    public string shootButton;
    public string horizontalInput;
    public string verticalInput;
    public string aimXInput;
    public string aimYInput;
    public string punchButton;
    public string jumpButton;








    // Start is called before the first frame update
    void Start()
    {

        SetupInstances();
        playerTransform = transform;

        healthControl = gameObject.GetComponent<HealthControl>();

        rig = aimingRig.GetComponent<Rig>();
        machine.Set(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        grounded = groundCheck();

        if (!disableControl)
        {
            xInput = Input.GetAxis(horizontalInput);
            if (!disableJump())
            {
            handleJumpInput();

            }
        }
        HitStopControl(Time.time);
        if (machine.state)
        {

            machine.state.DoBranch();
            machine.state.GetCurrentState();
        }
        stateForDebug = machine.state;
        SelectState();


    }

    private void FixedUpdate()
    {
        machine.state.FixedDoBranch();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }

    private void handleJumpInput()
    {
        if (Input.GetButtonDown(jumpButton))
        {
            Debug.Log("JUMP" + jumpButton);
            rb.velocity = new Vector3(0, airborneState.jumpForce);
        }
    }

    private bool groundCheck()
    {
        if (Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, maxDistance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void equipRangedWeapon(bool value)
    {
        hasRangedWeapon = value;
    }
    public void applyHitForce(Vector3 collisionNormal)
    {
        rb.AddForce(collisionNormal * knockbackForce, ForceMode.Impulse);
    }

    public void HitStop(float time, float hitStopDuration)
    {
        this.hitStopEnd = time + hitStopDuration;

    }

    void HitStopControl(float time)
    {
        if (time < hitStopEnd)
        {
            Debug.Log("HitStop");
            animator.speed = 0;

        }
        else
        {
            animator.speed = 1;
        }
    }

    void SelectState()
    {
        print("machinestate" + groundedState.currentState);
        if (!HasHealth())
        {
            machine.Set(deadState);
        }
        else if (hit)
        {
            machine.Set(hitState);
        }
        else if (grounded)
        {
            machine.Set(groundedState);
        }
       else
        {
            machine.Set(airborneState);
        }

    }

    bool HasHealth()
    {
        if (healthControl.health > 0)
        {
            return true;
        }
        return false;
    }

    bool disableJump()
    {
        if (groundedState.currentState == punchingState || groundedState.currentState == secondPunchState || groundedState.currentState == thirdPunchState || groundedState.currentState == chargedKickState) return true;

        return false;    
    }
}
