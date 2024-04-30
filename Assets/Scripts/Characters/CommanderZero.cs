using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommanderZero : MonoBehaviour , IInteractable
{
    public bool canInteract = true;
    public Flowchart fungusFlowchart;


    public void Interact()
    {
        if (canInteract)
        {
            if(fungusFlowchart.GetBooleanVariable("StartedTheFirsInteract") == false)
            {
                fungusFlowchart.ExecuteBlock("Take First Quest");
            }
            else if (fungusFlowchart.GetBooleanVariable("FragmentsCollected") == true && fungusFlowchart.GetBooleanVariable("Act1_Completed") == false)
            {
                fungusFlowchart.ExecuteBlock("Take The Second Quest");
            }
        }
    }

    public bool CanInteract()
    {
        return canInteract;
    }

    public void setInteractToFalse()
    {
        canInteract = false;
    }

    public void setInteractToTrue()
    {
        canInteract = true;
    }
}
