using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNum : MonoBehaviour
{
    int triggerNum;

    public List<GameObject> firstSteps;

    public void FindTrigger(string name)
    {
        int foundnum = 0;
        foreach (GameObject step in firstSteps)
        {
            if (step != null)
            {
                if (step.name == name)
                {
                    triggerNum = foundnum;
                    Debug.Log("Trigger num is: " + triggerNum);
                    step.GetComponentInChildren<FirstStepThree>()?.GetNum(triggerNum);
                    break;
                }
                foundnum++;
            }
        }
    }
}
