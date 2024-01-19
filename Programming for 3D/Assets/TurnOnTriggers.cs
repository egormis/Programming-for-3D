using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTriggers : MonoBehaviour
{
    public List<GameObject> doorAnimations;

    // Method to turn off all door animations
    public void TurnOnAllDoorAnimations()
    {
        foreach (GameObject doorAnimation in doorAnimations)
        {
            if (doorAnimation != null)
            {
                doorAnimation.SetActive(true);
            }
        }
    }
}
