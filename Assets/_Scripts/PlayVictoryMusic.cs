using UnityEngine;

public class PlayVictoryMusic : MonoBehaviour
{
    public AudioClip soundEffect; // Reference to the audio clip
    private AudioSource audioSource; // Reference to the audio source component
    public DoorInteractor doorController;

    private bool hasPlayed = false;  // Track if the sound has been played

    void Start()
    {
        // Add an AudioSource component to the game object and set up the audio
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect;
    }

    void Update()
    {
        // Check if the door has just been opened
        if (doorController != null && doorController.isOpened && !hasPlayed)
        {
            audioSource.Play();
            hasPlayed = true;  // Prevent the sound from playing again while the door is open
        }
        // Stop the sound when the door is closed
        else if (doorController != null && !doorController.isOpened && hasPlayed)
        {
            audioSource.Stop();  // Stop the sound when the door is closed
            hasPlayed = false;   // Reset the flag to allow the sound to play again next time the door opens
        }
    }
}
