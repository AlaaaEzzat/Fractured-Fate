using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectIteams : MonoBehaviour
{
    public Flowchart fungusFlowchart;
    public UnityEvent IncreaseIteams;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && fungusFlowchart.GetBooleanVariable("StartedTheFirsInteract") == true)
        {
            fungusFlowchart.ExecuteBlock("CollectFragments");
            //CompleteInteraction?.Invoke();
            // fungusFlowchart.SetBooleanVariable("Act1_Completed", true);
        }
    }
}
