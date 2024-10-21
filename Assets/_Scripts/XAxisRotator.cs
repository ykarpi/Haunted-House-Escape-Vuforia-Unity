using UnityEngine;

public class XAxisRotator : MonoBehaviour
{
    [Tooltip("Speed of rotation around X-axis")]
    public float rotationSpeed = 50f;  // Speed of the rotation, you can adjust this

    void Update()
    {
        // Rotate the key around its local X-axis
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}