using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartOfTheGame : MonoBehaviour
{
    [SerializeField] private Animator mainCam = null;
    [SerializeField] private GameObject heroObject = null; // GameObject that contains the Hero script
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private TextMeshProUGUI task;

    private Hero heroScript;
    private bool textCoroutineStarted = false; // Flag to check if coroutine is started

    // Use this for initialization
    void Start()
    {
        mainCam.Play("1 Scene", 0, 0.0f);
        
        // Ensure heroObject is assigned and get the Hero script
        if (heroObject != null)
        {
            heroScript = heroObject.GetComponent<Hero>();
            // Initially disable the Hero script if it's not null
            if (heroScript != null)
            {
                heroScript.enabled = false;
            }
        }

        // Initially disable the textMesh if it's not null
        if (textMesh != null)
        {
            textMesh.enabled = false;
        }

        if (task != null)
        {
            task.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Animator is playing the desired animation on layer 0
        if (mainCam.GetCurrentAnimatorStateInfo(0).IsName("1 Scene"))
        {
            // Check if the animation is at its end
            if (mainCam.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && !textCoroutineStarted)
            {
                // Disable the Animator component
                mainCam.enabled = false;

                // Enable the Hero script and the text
                if (heroScript != null)
                {
                    heroScript.enabled = true;
                    textMesh.enabled = true;
                    task.enabled = true;
                    if (!textCoroutineStarted){
                       StartCoroutine(HideTextAfterTime(5));
                       textCoroutineStarted = true; 
                    }
                       
                }
            }
        }
    }

    IEnumerator HideTextAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        textMesh.enabled = false;
    }
}




