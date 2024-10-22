using UnityEngine;

public class PlayVictoryMusic : MonoBehaviour
{
    // add audio stuff :"D
    public AudioClip soundEffect; // reference to the audio clip
    private AudioSource audioSource; // reference to the audio source component
    public DoorInteractor doorController;  
    
    void Start()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect;

    }

    void Update()
    {
       if (doorController is not null && doorController.isOpened) audioSource.Play();
       
    }
    
}