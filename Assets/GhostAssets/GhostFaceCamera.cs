using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFaceCamera : MonoBehaviour
{
    // Reference to the camera (typically the main camera)
    private Transform cameraTransform;

    private void Start()
    {
        // Get the main camera's transform
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Make the object look at the camera
        LookAtCamera();
    }

    private void LookAtCamera()
    {
        // Get the direction from the object to the camera
        Vector3 directionToCamera = cameraTransform.position - transform.position;

        // Set the object to face the camera by rotating only on the y-axis (to keep it upright)
        directionToCamera.y = 0;

        // Update the rotation of the object to look at the camera
        transform.rotation = Quaternion.LookRotation(directionToCamera);
    }
}
