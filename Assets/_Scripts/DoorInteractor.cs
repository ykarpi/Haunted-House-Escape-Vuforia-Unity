using UnityEngine;

public class DoorInteractor : MonoBehaviour
{
    public bool locked = false;
    public bool canOpen = true; // Allow opening the door
    public bool canClose = true; // Allow closing the door
    public bool isOpened = false; // Track the door state (open or closed)

    private Rigidbody _rbDoor;
    private HingeJoint _hinge;

    public float maxOpenAngle = 85f; // Max angle for fully opened door
    public float openSpeed = 100f; // Speed of the door opening (force for motor)
    private JointMotor _motor;

    void Start()
    {
        _rbDoor = GetComponent<Rigidbody>();
        _hinge = GetComponent<HingeJoint>();

        JointLimits limits = _hinge.limits;
        limits.max = maxOpenAngle;
        limits.min = 0; // Closed position
        _hinge.limits = limits;

        _motor = new JointMotor
        {
            targetVelocity = openSpeed,
            force = 1000f // Adjust based on your door's mass
        };

        _hinge.motor = _motor;

    }

    void Update()
    {
        // Detect if the "O" key is pressed
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToggleDoor(); // Trigger door open/close action
        }
    }

    private void ToggleDoor()
    {
        if (isOpened)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (isOpened || !canOpen) return;
        isOpened = true;
        _hinge.useMotor = true;
        Debug.Log("Door is opened");
    }

    private void CloseDoor()
    {
        if (!isOpened || !canClose) return;
        isOpened = false;
        
        // Gradually close the door
        while (_hinge.angle > 0.1f) // Close until it's nearly closed
        {
            // Apply torque to close the door
            _rbDoor.AddRelativeTorque(new Vector3(0, 0, -openSpeed * Time.deltaTime));
        }
        Debug.Log("Door is closing");
    }

}
