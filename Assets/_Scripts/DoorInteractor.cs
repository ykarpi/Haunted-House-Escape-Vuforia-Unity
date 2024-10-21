using UnityEngine;

public class DoorInteractor : MonoBehaviour
{
    public bool locked = false;
    public bool canOpen = true;  // Allow opening the door
    public bool canClose = true; // Allow closing the door
    public bool isOpened = false; // Track the door state (open or closed)

    private Rigidbody _rbDoor;
    private HingeJoint _hinge;
    private JointMotor _motor;

    public float maxOpenAngle = 85f; // Max angle for fully opened door
    public float openSpeed = 50f;    // Speed of the door opening (degrees per second)
    public float closeSpeed = 30f;   // Speed of the door closing (degrees per second)

    void Start()
    {
        _rbDoor = GetComponent<Rigidbody>();
        _hinge = GetComponent<HingeJoint>();
        
        _hinge.useMotor = true; // Enable the motor
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

        // Set motor for opening
        _motor = _hinge.motor;
        _motor.targetVelocity = openSpeed;
        _motor.force = 30f;  // Adjust based on your door's mass
        _hinge.motor = _motor;

        // Set the limits for opening
        JointLimits limits = _hinge.limits;
        limits.max = maxOpenAngle;
        limits.min = 0;
        _hinge.limits = limits;

        Debug.Log("Door is opening");
    }

    private void CloseDoor()
    {
        if (!isOpened || !canClose) return;
        isOpened = false;

        // Set motor for closing
        _motor = _hinge.motor;
        _motor.targetVelocity = -closeSpeed;  // Negative speed to close the door
        _motor.force = 50f;  // Adjust force based on your door's mass
        _hinge.motor = _motor;

        Debug.Log("Door is closing");
    }
}
