using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViktorNpc : MonoBehaviour , IInteractable
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
            if(fungusFlowchart.GetBooleanVariable("TalkToViktor") == true && fungusFlowchart.GetBooleanVariable("Collected") == true)
            {
                fungusFlowchart.ExecuteBlock("Act3");
            }
            else
            {
                fungusFlowchart.ExecuteBlock("Act2");
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
