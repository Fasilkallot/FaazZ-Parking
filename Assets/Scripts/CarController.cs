
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentBreakForce,HandBreakForce;
    public bool isBraking;
    public bool isParking;

    [SerializeField] int index;

    // Settings 

    [SerializeField] private float motorForce, breakForce, maxSteerAngle, parkForce;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheel, frontRightWheel;
    [SerializeField] private WheelCollider rearLeftWheel, rearRightWheel;

    // Wheel 
    [SerializeField] private Transform frontLeft, frontRight;
    [SerializeField] private Transform backLeft, backRight;


    private void OnEnable()
    {
        if (GameManager.Instance.players[index] == null)            
        GameManager.Instance.players[index] = this.gameObject;
        else Destroy(gameObject);
        if (GameManager.Instance.player == null)
        GameManager.Instance.player = this.gameObject;

        this.gameObject.transform.parent = null;
        this.gameObject.tag = "Player";
        DontDestroyOnLoad(this.gameObject);

    }
    private void OnDisable()
    {
        if(GameManager.Instance.player == this.gameObject) GameManager.Instance.player = null;  
    }
    private void Awake()
    {
    }
    private void Start()
    {
        GameManager.Instance.carController = this;
    }
    private void Update()
    {

        GetInput();
    }
    private void FixedUpdate()
    {
        HandleMotor();
        HandleStearing();
        UpdateWheel();
    }

    private void HandleMotor()
    {
        frontLeftWheel.motorTorque = verticalInput * motorForce;
        frontRightWheel.motorTorque = verticalInput *motorForce;

        currentBreakForce = isBraking ? breakForce :0f;
        HandBreakForce = isParking ? parkForce :0f;

        ApplyBreaking();
        HandBreak();
    }

    public void ApplyBreaking()
    {
        frontRightWheel.brakeTorque = currentBreakForce;
        frontLeftWheel.brakeTorque = currentBreakForce;
        rearLeftWheel.brakeTorque = currentBreakForce;
        rearRightWheel.brakeTorque = currentBreakForce;
    }

    private void UpdateWheel()
    {
        UpdateSingleWheel(frontLeftWheel, frontLeft);
        UpdateSingleWheel(frontRightWheel, frontRight);
        UpdateSingleWheel(rearLeftWheel, backLeft);
        UpdateSingleWheel(rearRightWheel, backRight);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelMesh)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);

        wheelMesh.position = pos;
        wheelMesh.rotation = rot;

    }

    private void HandleStearing()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;

        frontRightWheel.steerAngle = currentSteerAngle;
        frontLeftWheel.steerAngle = currentSteerAngle;
    }

    private void GetInput()
    {
        // Steering Input
        horizontalInput = SimpleInput.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = SimpleInput.GetAxis("Vertical");

        // Break Input
       // isBraking = SimpleInput.GetKey(KeyCode.Space);

        // Park Input            
        if(Input.GetKeyDown(KeyCode.P))
            isParking = !isParking;       
    }
    private void HandBreak()
    {
        if (!isParking) return;

        frontRightWheel.brakeTorque = HandBreakForce;
        frontLeftWheel.brakeTorque = HandBreakForce;
        rearLeftWheel.brakeTorque = HandBreakForce;
        rearRightWheel.brakeTorque = HandBreakForce;
    }
    

}