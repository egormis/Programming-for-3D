using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstStepThree : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private TextMeshProUGUI task;
    [SerializeField] private TextMeshProUGUI prevTask;

    [SerializeField] private InteractionWithItem interactionWithItem;
    private bool isPlayerInTrigger = false;
    private bool isTextShown = true;

    public MonsterManager playMonster;
    public TurnOffTriggers turnOffTriggers;
    public TurnOnTriggers turnOnTriggers;

    public GameObject nextTrigger;

    [SerializeField] private TriggerNum triggerFinder;
    
    private int triggerNum;

    [SerializeField] private LightBlinking lightBlinking;

    private void Start() {
        interactionWithItem.enabled = false;
        if (triggerFinder != null)
        {
            string triggerName = this.name;
            triggerFinder.FindTrigger(triggerName);
        }
        
    }
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (isTextShown)
            {
                // Hide text, play monster animation, and turn off door animations
                if (textMesh != null) textMesh.enabled = false;
                if (playMonster != null) playMonster.PlayMonster(triggerNum);
                if (turnOffTriggers != null) turnOffTriggers.TurnOffAllDoorAnimations();
                if (turnOnTriggers != null) turnOnTriggers.TurnOnAllDoorAnimations();
                if (nextTrigger != null) nextTrigger.SetActive(true);
                if (lightBlinking != null) lightBlinking.StartBlinking();
                isTextShown = false;
            }
            else
            {
                // Show text and set isTextShown to true for next interaction
                if (textMesh != null) textMesh.enabled = true;
                isTextShown = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            if (textMesh != null) textMesh.enabled = true; // Show text
            isTextShown = true;
            interactionWithItem.enabled = true;
            prevTask.enabled = false;
            task.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            if (textMesh != null) textMesh.enabled = false; // Hide text
            isTextShown = false; // Reset for next interaction
            interactionWithItem.enabled = false;
        }
    }

    public void GetNum(int num) {
        triggerNum = num;
    }

    


}


