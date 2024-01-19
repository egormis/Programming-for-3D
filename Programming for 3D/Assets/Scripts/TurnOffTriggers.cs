using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffTriggers : MonoBehaviour
{
    public List<GameObject> doorAnimations;

    // Method to turn off all door animations
    public void TurnOffAllDoorAnimations()
    {
        foreach (GameObject doorAnimation in doorAnimations)
        {
            if (doorAnimation != null)
            {
                doorAnimation.SetActive(false);
            }
        }
    }
}

