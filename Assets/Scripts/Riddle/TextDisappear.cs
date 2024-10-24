using System.Collections;  // Required for IEnumerator and coroutines
using UnityEngine;
using TMPro;  // Required for TextMeshProUGUI

public class TextDisplay : MonoBehaviour
{
    public TextMeshProUGUI myText;  // Reference to the TextMeshPro Text object
    public float displayDuration = 5f;  // Duration in seconds for the text to stay visible

    void Start()
    {
        // Ensure the text starts visible when the scene initializes
        myText.gameObject.SetActive(true);
        
        // Start the coroutine to hide the text after the specified time
        StartCoroutine(HideTextAfterTime());
    }

    IEnumerator HideTextAfterTime()
    {
        // Wait for the displayDuration (5 seconds by default)
        yield return new WaitForSeconds(displayDuration);

        // Hide the text after the wait
        myText.gameObject.SetActive(false);
    }
}