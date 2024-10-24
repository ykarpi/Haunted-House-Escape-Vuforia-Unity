using UnityEngine;

public class KeyHighlighter : MonoBehaviour
{
    private Renderer keyRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow;  // Color to highlight the key

    // Reference to the door controller
    public DoorInteractor doorController;  // Drag the AR_DoorTouchController here in the Inspector

    void Start()
    {
        keyRenderer = GetComponent<Renderer>();
        originalColor = keyRenderer.material.color;  // Store the original color
        HighlightKey();
    }

    public void HighlightKey()
    {
        if (keyRenderer != null)
        {
            keyRenderer.material.color = highlightColor;
        }
    }

    public void RevertKeyColor()
    {
        if (keyRenderer != null)
        {
            keyRenderer.material.color = originalColor;
        }
    }

    void Update()
    {
        // Continuously check the door's state to update the key highlight
        if (doorController != null)
        {
            if (doorController.isOpened)
            {
                HighlightKey();
            }
            else
            {
                RevertKeyColor();
            }
        }
    }
}