using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStepTwo : MonoBehaviour
{
    [SerializeField] private Animator monster = null;
    
    [SerializeField] private GameObject firstStep;
    
    private bool activated = false;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!activated)
        {
            if (other.CompareTag("Player")) {
                monster.Play("Var 2", 0, 0.0f);
                firstStep.SetActive(false);
                activated = true;
            }
        }
    }
}
