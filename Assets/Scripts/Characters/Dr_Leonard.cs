using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dr_Leonard : MonoBehaviour , IInteractable
{
    public bool canInteract;
    public Flowchart fungusFlowchart;

    private void Start()
    {
        canInteract = false;
    }

    public void Interact()
    {
        if (canInteract)
        {
            if (fungusFlowchart.GetBooleanVariable("TalkToDrLeo") == true && fungusFlowchart.GetBooleanVariable("Collected") == true)
            {
                fungusFlowchart.ExecuteBlock("Act3.1");
            }
            else
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
