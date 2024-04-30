using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea2 : MonoBehaviour
{
    [SerializeField] private Flowchart flow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flow.ExecuteBlock("TriggerArea2");
            Destroy(this.gameObject);
        }
    }
}
