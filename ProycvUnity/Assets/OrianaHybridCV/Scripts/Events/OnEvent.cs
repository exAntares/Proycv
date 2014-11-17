using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnEvent<T> : MonoBehaviour where T : EventExecuterBase
{
    public List<T> EventsActions = new List<T>();

    void Start()
    {
        foreach (T activateEvent in EventsActions)
        {
            activateEvent.Register();
        }
    }
}

public class EventExecuterBase
{
    public string eventName = "";

    public EventsObserver EventOwner = null;

    public virtual void DoAction() { }

    public void Register()
    {
        if (EventOwner)
        {
            EventOwner.RegisterFunctionToEvent(DoAction, eventName);
        }
    }
}