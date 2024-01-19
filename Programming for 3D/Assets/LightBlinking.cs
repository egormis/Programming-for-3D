using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinking : MonoBehaviour
{
    public List<GameObject> lights;
    public float blinkInterval = 0.5f; // Time in seconds for each blink state

    private Coroutine blinkingCoroutine;

    // Method to turn off all lights
    public void TurnOffLight()
    {
        foreach (GameObject light in lights)
        {
            if (light != null)
            {
                light.SetActive(false);
            }
        }
    }

    // Method to turn on all lights
    public void TurnOnLight()
    {
        foreach (GameObject light in lights)
        {
            if (light != null)
            {
                light.SetActive(true);
            }
        }
    }

    // Coroutine for blinking lights a random number of times
    public IEnumerator BlinkLights()
    {
        int blinkTimes = Random.Range(3, 7); // Random number between 3 and 6
        for (int i = 0; i < blinkTimes; i++)
        {
            TurnOffLight();
            yield return new WaitForSeconds(blinkInterval);
            TurnOnLight();
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    // Start blinking the lights
    public void StartBlinking()
    {
        if (blinkingCoroutine != null)
        {
            StopCoroutine(blinkingCoroutine);
        }
        blinkingCoroutine = StartCoroutine(BlinkLights());
    }

    // Stop blinking the lights
    public void StopBlinking()
    {
        if (blinkingCoroutine != null)
        {
            StopCoroutine(blinkingCoroutine);
            blinkingCoroutine = null;
        }
        TurnOnLight(); // Ensure all lights are on after stopping
    }
}

