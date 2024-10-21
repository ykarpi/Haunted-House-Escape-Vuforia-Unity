using UnityEngine;

public class AR_DoorTouchController : MonoBehaviour
{
    [Tooltip("If it is false, door can't be used")]
    public bool Locked = false;  // Keep this if you still want to lock the door for other purposes
    [Space]
    public bool CanOpen = true;  // Allow opening the door
    public bool CanClose = true; // Allow closing the door
    [Space]
    public bool isOpened = false; // Track the door state (open or closed)
    [Range(0f, 4f)]
    [Tooltip("Speed for door opening, degrees per second")]
    public float OpenSpeed = 3f;  // Speed of door opening

    // Variables for door physics
    Rigidbody rbDoor;
    HingeJoint hinge;
    JointLimits hingeLim;
    float currentLim;

    void Start()
    {
        // Initialize Rigidbody and HingeJoint for the door
        rbDoor = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        // Detect touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Cast a ray from the touch position
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            // Check if the ray hits the door object
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)  // If the hit object is the door
                {
                    Action();  // Trigger door open/close action
                }
            }
        }

        // Detect if the "O" key is pressed
        if (Input.GetKeyDown(KeyCode.O))
        {
            Action();  // Trigger door open/close action
        }
    }

    public void Action() // Method to open/close door
    {
        if (!Locked)  // Check if door is not locked
        {
            // Opening/closing logic
            if (isOpened && CanClose)  // If door is open and can close
            {
                isOpened = false;  // Close the door
            }
            else if (!isOpened && CanOpen)  // If door is closed and can open
            {
                isOpened = true;  // Open the door
                rbDoor.AddRelativeTorque(new Vector3(0, 0, 20f));  // Apply torque to open door
            }
        }
    }

    private void FixedUpdate() // Physics-based door control
    {
        // Adjust the hinge joint's angle limits based on whether the door is open or closed
        if (isOpened)
        {
            currentLim = 180f;  // Open door to a max of 120 degrees (increase this for a wider opening)
        }
        else
        {
            if (currentLim > 1f)
                currentLim -= .5f * OpenSpeed;  // Gradually close the door
        }

        // Set the hinge joint limits based on current limits
        hingeLim.max = currentLim;
        hingeLim.min = -currentLim;
        hinge.limits = hingeLim;
    }
}
