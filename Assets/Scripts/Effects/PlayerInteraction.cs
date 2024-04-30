using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactionPrompt;
    public IInteractable interactableObject;
    public bool canInteract = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            CheckForInteractableObject();
            canInteract = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && other.GetComponent<IInteractable>() != null)
        {
            interactableObject = other.GetComponent<IInteractable>();
            if (interactableObject.CanInteract() && interactionPrompt != null)
            {
                interactionPrompt.gameObject.SetActive(true);
            }
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if(interactionPrompt != null && interactionPrompt.gameObject.activeInHierarchy == true)
            {
                interactionPrompt.gameObject.SetActive(false);
            }
            canInteract = false;
        }
    }

    void CheckForInteractableObject()
    {
        if (interactableObject != null && interactableObject.CanInteract())
        {
            interactableObject.Interact();
        }
    }
    
    public void SetInteractionToFalse()
    {
        canInteract = false;
    }
}
