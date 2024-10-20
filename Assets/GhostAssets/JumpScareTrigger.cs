using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{

    [SerializeField] private GameObject imgTarget;
    private DefaultObserverEventHandler imgTargetHandler;

    private bool targetFound = false;
    private bool jumpScare = false;
    private bool isPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
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
        //do somrthing
        Debug.Log("FOUND!!!!");
    }
}
