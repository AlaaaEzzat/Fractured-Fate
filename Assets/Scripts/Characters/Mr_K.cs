using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mr_K : MonoBehaviour, IInteractable
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
            if(fungusFlowchart.GetBooleanVariable("FinalAct") == true)
            {
                fungusFlowchart.ExecuteBlock("FinalAct");
            }
            else
            {
                fungusFlowchart.ExecuteBlock("Talk With Mr.K");
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
