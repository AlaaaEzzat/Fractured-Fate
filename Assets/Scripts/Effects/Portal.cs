using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    public GameObject newPosition;
    public DistanceShader shad;
    public GameObject newMap;
    public GameObject currentMap;
    private CharacterController playerController;
    public ChangeEffect changeEffect;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            changeEffect.ActiveEffect = true;
            newMap.SetActive(true);
            playerController = other.GetComponent<CharacterController>();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            if(shad.activate == false)
            {
                shad.activate = true;
            }
            else
            {
                shad.activate = false;
            }
            //playerController.enabled = false;
            StartCoroutine(wait());

        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(7);
        // other.gameObject.transform.position = newPosition.transform.position;
        playerController.enabled = true;
        currentMap.SetActive(false);
        GameObject temp;
        temp = newMap;
        newMap = currentMap;
        currentMap = temp;
        this.gameObject.SetActive(false);
    }
}
