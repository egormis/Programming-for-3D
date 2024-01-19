using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStepOne : MonoBehaviour
{
    [SerializeField] private Animator monster = null;
    [SerializeField] private GameObject firstStep;
    
    private bool activated = false;

    void OnTriggerEnter(Collider other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            Debug.Log("PLAYER DETECTED");
            monster.Play("Var 1", 0, 0.0f);
            StartCoroutine(WaitForAnimationEnd("Var 1"));
            activated = true;
            firstStep.SetActive(false);
        }
    }

    private IEnumerator WaitForAnimationEnd(string animationName)
    {
        // Wait until the animation starts
        yield return new WaitWhile(() => monster.GetCurrentAnimatorStateInfo(0).IsName(animationName) == false);

        // Now wait until the animation has finished
        yield return new WaitUntil(() => monster.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);

        // At this point, the animation has finished
        Debug.Log("Animation Completed");
        // Perform further actions after animation has completed
    }
}

