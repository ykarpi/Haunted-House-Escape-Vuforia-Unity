using UnityEngine;

public class KeyHighlighter : MonoBehaviour
{
    private Renderer keyRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow;  // Color to highlight the key

    void Start()
    {
        // Get the Renderer component to modify the key's material
        keyRenderer = GetComponent<Renderer>();
        originalColor = keyRenderer.material.color;  // Store the original color
    }

    // Method to highlight the key
    public void HighlightKey()
    {
        if (keyRenderer != null)
        {
            keyRenderer.material.color = highlightColor;
        }
    }

    // Method to revert the key's color to the original
    public void RevertKeyColor()
    {
        if (keyRenderer != null)
        {
            keyRenderer.material.color = originalColor;
        }
    }
}