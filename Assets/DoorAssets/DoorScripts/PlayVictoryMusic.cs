using UnityEngine;
using TMPro;  // Import TextMeshPro namespace

public class PlayVictoryMusic : MonoBehaviour
{
    public AudioClip soundEffect;  // Reference to the audio clip
    private AudioSource audioSource;  // Reference to the audio source component
    public DoorInteractor doorController;  // Reference to the door controller
    public TextMeshProUGUI victoryText;  // Reference to the TextMeshProUGUI component

    private bool hasPlayed = false;  // Track if the sound has been played

    void Start()
    {
        // Add an AudioSource component to the game object and set up the audio
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect;

        // Ensure the TextMeshProUGUI starts inactive
        if (victoryText != null)
        {
            victoryText.gameObject.SetActive(false);  // Text is inactive at the start
        }
    }

    void Update()
    {
        // Check if the door has just been opened
        if (doorController != null && doorController.isOpened && !hasPlayed)
        {
            audioSource.Play();  // Play the victory music
            hasPlayed = true;  // Prevent the sound from playing again while the door is open

            // Activate the TextMeshProUGUI when the door is opened
            if (victoryText != null)
            {
                victoryText.gameObject.SetActive(true);
            }
        }
        // Stop the sound and deactivate the text when the door is closed
        else if (doorController != null && !doorController.isOpened && hasPlayed)
        {
            audioSource.Stop();  // Stop the sound when the door is closed
            hasPlayed = false;  // Reset the flag to allow the sound to play again next time the door opens

            // Deactivate the TextMeshProUGUI when the door is closed
            if (victoryText != null)
            {
                victoryText.gameObject.SetActive(false);
            }
        }
    }
}