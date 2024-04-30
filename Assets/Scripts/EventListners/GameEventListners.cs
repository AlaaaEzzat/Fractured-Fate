using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListners : MonoBehaviour
{
    public VoidEventListner Event;

    public UnityEvent respond;

    private void OnEnable()
    {
        Event.RegesterListner(this);
    }

    private void OnDisable()
    {
        Event.UnResgterListner(this);
    }

    public void OnEventInvoke()
    {
        respond.Invoke();
    }
}
