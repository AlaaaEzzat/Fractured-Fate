using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fragments : MonoBehaviour, IInteractable
{
    public bool canInteract = true;
    public Flowchart fungusFlowchart;


    public void Interact()
    {
        // Check if the object can be interacted with
        if (canInteract && fungusFlowchart.GetBooleanVariable("StartedTheFirsInteract") == true)
        {
            fungusFlowchart.ExecuteBlock("CollectFragments");
            canInteract = false;
            Destroy(gameObject);
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
