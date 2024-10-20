using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDelayedVisualization : MonoBehaviour
{
    // Assign the model to this variable in the Unity Inspector
    [SerializeField] private GameObject model;

    // Ensure the model is initially inactive
    private void Start()
    {
        if (model != null)
        {
            model.SetActive(false);
        }
    }

    // The function to be triggered by the OnClick event
    public void ShowModelWithDelay()
    {
        if (model != null)
        {
            StartCoroutine(ShowModelCoroutine());
        }
        else
        {
            Debug.LogError("Model is not assigned!");
        }
    }

    // Coroutine to show the model for 3 seconds
    private IEnumerator ShowModelCoroutine()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Set the model to active (visible)
        model.SetActive(true);
    }
}
