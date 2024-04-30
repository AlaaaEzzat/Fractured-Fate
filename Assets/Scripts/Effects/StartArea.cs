using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArea : MonoBehaviour
{
    public DistanceShader shad;
    public ChangeEffect changeEffect;
    public GameObject UI , arrow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shad.activate = false;
            changeEffect.ActiveEffect = true;
            UI.SetActive(true);
            arrow.SetActive(true);
            Destroy(gameObject);
        }
    }
}
