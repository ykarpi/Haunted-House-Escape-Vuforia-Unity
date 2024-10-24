using UnityEngine;

public class DoorInteractor : MonoBehaviour
{
    public float openAngle = 90f;  // Angle for the open position (Y-axis)
    public float closeAngle = 0f;  // Angle for the closed position (Y-axis)
    public float rotationSpeed = 2f;  // Speed of the door rotation
    public bool isOpened = false;  // Track whether the door is open or closed
    public GameObject door;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Detect if the touch is on the door
            Vector2 touchPosition = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            // Perform the raycast and check if it hits the door
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == door) // Ensure the touch is on the door
                {
                    ToggleDoor(); // Trigger door open/close only when the door is touched
                }
            }
        }
        // Smoothly rotate the door around the local Y-axis
        // Maintain the original X and Z rotation while rotating around the Y-axis
        float targetAngle = isOpened ? openAngle : closeAngle;
        Quaternion targetRotation = Quaternion.Euler(transform.localEulerAngles.x, targetAngle, transform.localEulerAngles.z);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void ToggleDoor()
    {
        isOpened = !isOpened;  // Toggle the door state
    }
}