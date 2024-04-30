using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName =("EventListnersSC/Event"))]
public class VoidEventListner : ScriptableObject
{
    private List<GameEventListners> listners = new List<GameEventListners>();

    public void RegesterListner(GameEventListners listner)
    {
        listners.Add(listner);
    }

    public void UnResgterListner(GameEventListners listner)
    {
        listners.Remove(listner);
    }

    public void Raised()
    {
        for (int i = listners.Count - 1; i >= 0; i--)
        {
            listners[i].OnEventInvoke();
        }
    }
}
