using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostAnimationIdle : MonoBehaviour
{

    [SerializeField] private GameObject imgTarget;
    private DefaultObserverEventHandler imgTargetHandler;

    [SerializeField] private GameObject jumpScareTriggerGameObject;
    private JumpScareTrigger jumpScareTrigger;

    private Animator animator;
    private bool jumpScareIsPlayed;

    // Start is called before the first frame update
    void Start()
    {
        var imgTargetHandler = imgTarget.GetComponent<DefaultObserverEventHandler>();

        if (imgTargetHandler == null)
        {
            Debug.LogError("DefaultObserverEventHandler component is missing!");
            return;
        }


        var jumpScareTrigger = jumpScareTriggerGameObject.GetComponent<JumpScareTrigger>();
        jumpScareIsPlayed = jumpScareTrigger.isPlayed;


        imgTargetHandler.OnTargetFound.AddListener(OnTargetDetected);
    }

    private void Update()
    {
        if (jumpScareTrigger != null & !jumpScareIsPlayed)
        {
            if (jumpScareTrigger.isPlayed == true)
            {
                jumpScareIsPlayed = true;
            }
        }
        Debug.Log("Status of the bool:" + jumpScareIsPlayed);

    }


    void OnTargetDetected()
    {
        if (jumpScareIsPlayed == true)
        {
            PlayAnimation();
        }
        
    }

    void PlayAnimation()
    {
        animator.Play("CharacterArmature|Flying_Idle");
    }
}
