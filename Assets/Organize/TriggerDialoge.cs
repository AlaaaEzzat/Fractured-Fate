using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Events;

public class TriggerDialoge : MonoBehaviour
{
    public Flowchart fungusFlowchart;
    public UnityEvent CompleteInteraction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && fungusFlowchart.GetBooleanVariable("StartedTheFirsInteract") == false)
        {
            fungusFlowchart.ExecuteBlock("Take First Quest");
           // fungusFlowchart.SetBooleanVariable("Act1_Completed", true);
        }
        else if (other.CompareTag("Player") && fungusFlowchart.GetBooleanVariable("FragmentsCollected") == true && fungusFlowchart.GetBooleanVariable("Act1_Completed") == false)
        {
            fungusFlowchart.ExecuteBlock("Take The Second Quest");
            CompleteInteraction?.Invoke();
        }
    }
}
