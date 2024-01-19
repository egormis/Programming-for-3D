using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class InteractionWithItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    public GameObject playerUIPicture; 

    [SerializeField] private GameObject key;
    private bool showItem = false;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        playerUIPicture.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!showItem)
            {
                // Show the UI picture and text
                if (playerUIPicture != null) playerUIPicture.SetActive(true);
                if (textMesh != null) textMesh.enabled = true;
                if (key != null) key.SetActive(false);
                
                showItem = true;
            }
            else
            {
                // Hide the UI picture and text
                if (playerUIPicture != null) playerUIPicture.SetActive(false);
                if (textMesh != null) textMesh.enabled = false;

                showItem = false;
            }
        }
    }
}


