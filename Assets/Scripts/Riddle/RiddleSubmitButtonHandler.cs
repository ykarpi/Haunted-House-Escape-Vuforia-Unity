using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class SubmitButtonHandler : MonoBehaviour
{
    [Header("UI Elements")]
    [Tooltip("The input field where the user types the answer.")]
    public TMP_InputField answerInputField;

    [Tooltip("The canvas that contains the input UI.")]
    public GameObject inputCanvas;

    [Tooltip("The placeholder text component of the input field.")]
    public TMP_Text placeholderText;

    [Tooltip("The correct answer.")]
    public string correctAnswer = "echo";

    [Header("Riddle Text")]
    [Tooltip("The TextMeshPro text component displaying the riddle.")]
    public TMP_Text riddleText;

    [Tooltip("The color to set for the riddle text upon correct answer.")]
    public Color successTextColor = new Color(144f / 255f, 238f / 255f, 144f / 255f); // Light Green

    [Header("Skull Model")]
    [Tooltip("The skull GameObject to be hidden upon correct answer.")]
    public GameObject skullObject;

    private string originalPlaceholderText;

    void Start()
    {
        // Validate essential references
        if (answerInputField == null)
        {
            Debug.LogError("Answer Input Field is not assigned.");
        }

        if (inputCanvas == null)
        {
            Debug.LogError("Input Canvas is not assigned.");
        }

        if (placeholderText == null)
        {
            Debug.LogError("Placeholder Text is not assigned.");
        }

        if (riddleText == null)
        {
            Debug.LogError("Riddle Text is not assigned.");
        }

        if (skullObject == null)
        {
            Debug.LogError("Skull Object is not assigned.");
        }

        // Store the original placeholder text
        if (placeholderText != null)
        {
            originalPlaceholderText = placeholderText.text;
        }

        // Assign the OnSubmitButtonClicked method to the Submit button's onClick event
        Button submitButton = GetComponent<Button>();
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(OnSubmitButtonClicked);
        }
        else
        {
            Debug.LogError("Submit Button Handler script must be attached to a Button.");
        }
    }

    // This method is called when the Submit button is clicked.
    public void OnSubmitButtonClicked()
    {
        string userInput = answerInputField.text.Trim().ToLower();
        string expectedAnswer = correctAnswer.ToLower();

        if (userInput == expectedAnswer)
        {
            HandleCorrectAnswer();
        }
        else
        {
            HandleIncorrectAnswer();
        }
    }

    // Handles the logic when the user provides the correct answer.
    private void HandleCorrectAnswer()
    {
        // Update riddle text and color
        if (riddleText != null)
        {
            riddleText.text = "You beat the riddle and shattered the skull's curse!";
            riddleText.color = successTextColor;
        }

        // Hide the skull model
        if (skullObject != null)
        {
            skullObject.SetActive(false);
        }

        // Hide the InputCanvas after a short delay
        StartCoroutine(HideInputCanvasAfterDelay(1f));
    }

    // Handles the logic when the user provides an incorrect answer.
    private void HandleIncorrectAnswer()
    {
        // Clear the input field
        answerInputField.text = "";

        // Change the placeholder text to "Try again"
        if (placeholderText != null)
        {
            placeholderText.text = "Try again";
        }

        // Reset placeholder text after a short delay
        StartCoroutine(ResetUIAfterDelay(2f));
    }

    // Coroutine to hide the InputCanvas after a specified delay.
    private IEnumerator HideInputCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (inputCanvas != null)
        {
            inputCanvas.SetActive(false);
        }
    }

    // Coroutine to reset the UI elements after a specified delay.
    private IEnumerator ResetUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (placeholderText != null)
        {
            placeholderText.text = originalPlaceholderText;
        }
    }
}