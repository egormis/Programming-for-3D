using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        myDoor.Play("Door Close", 0, 0.0f);
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) {
                myDoor.Play("Door Open", 0, 0.0f);
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            myDoor.Play("Door Close", 0, 0.0f);
            
        }
    }
}
