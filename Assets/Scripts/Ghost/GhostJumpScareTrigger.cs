using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScareTrigger : MonoBehaviour
{
    [SerializeField] private GameObject imgTarget;
    private DefaultObserverEventHandler imgTargetHandler;

    [SerializeField] private Image jumpScareImage;

    [SerializeField] private AudioSource jumpScareSound; // Add this for the sound

    public bool isPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the jumpScareImage is inactive at the start
        jumpScareImage.gameObject.SetActive(false);

        // Make sure the AudioSource is disabled at the start
        jumpScareSound.Stop();

        var imgTargetHandler = imgTarget.GetComponent<DefaultObserverEventHandler>();

        if (imgTargetHandler == null)
        {
            Debug.LogError("DefaultObserverEventHandler component is missing!");
            return;
        }

        imgTargetHandler.OnTargetFound.AddListener(OnTargetDetected);
    }

    void OnTargetDetected()
    {
        if (isPlayed == false)
        {
            //activate the jump scare for a limited time
            StartCoroutine(ShowJumpScare());

            // Making sure that it is played only once
            isPlayed = true;
        }
        else
        {
            return;
        }
    }

    private IEnumerator ShowJumpScare()
    {
        // Activate the image
        jumpScareImage.gameObject.SetActive(true);

        // Play the jump scare sound
        jumpScareSound.Play();

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Deactivate the image
        jumpScareImage.gameObject.SetActive(false);
    }
}