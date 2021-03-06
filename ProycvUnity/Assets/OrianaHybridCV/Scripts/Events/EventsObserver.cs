using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EventsObserver : MonoBehaviour {
    #region variables    
    //Table of Delegates by event's name <EventName, Delegate>
    public Dictionary<string, Action> DelegatesByEventName = new Dictionary<string, Action>();
    #endregion

    #region EventsInterface

    public void RegisterFunctionToEvent(Action VoidFunctionToAdd, string NamedEvent)
    {
        //Debug.Log(gameObject.name + " Registrando funcion " + FunctionVoidToAdd + " Al evento " + NamedEvent);
        if (DelegatesByEventName.ContainsKey(NamedEvent))
        {
            DelegatesByEventName[NamedEvent] += VoidFunctionToAdd;
        }
        else
        {
            DelegatesByEventName[NamedEvent] = VoidFunctionToAdd;
        }
    }

    public void UNRegisterFunctionToEvent(Action FunctionVoidToAdd, string NamedEvent)
    {
        //Debug.Log(gameObject.name + " Des Registrando funcion " + FunctionVoidToAdd + " Al evento " + NamedEvent);
        if (DelegatesByEventName.ContainsKey(NamedEvent))
        {
            DelegatesByEventName[NamedEvent] -= FunctionVoidToAdd;
        }
    }

    public Action GetEventAction(string EventName)
    {
        if (DelegatesByEventName.ContainsKey(EventName))
        {
            return DelegatesByEventName[EventName];
        }

        return null;
    }

    public void BroadCastEvent(string eventName)
    {
        if (DelegatesByEventName.ContainsKey(eventName))
        {
            Action delegateAction = DelegatesByEventName[eventName];
            if (delegateAction != null)
            {
                delegateAction();
            }
        }
        else
        {
            //Debug.Log("No hay delegados asignados para " + eventName);
        }
       
    }

    #endregion

    #region GameObject Interface
    void Start()
    {
        gameObject.BroadCastEvent("OnStart");
    }

    private void OnDestroy()
    {
        gameObject.BroadCastEvent("OnDestroy");
        DelegatesByEventName.Clear();
    }

    void OnMouseUpAsButton()
    {
        gameObject.BroadCastEvent("OnMouseUpAsButton");
    }

    void OnMouseOver()
    {
        gameObject.BroadCastEvent("OnMouseOver");
    }

    void OnMouseExit()
    {
        gameObject.BroadCastEvent("OnMouseExit");
    }

    #endregion
}

public static class EventsHandlerExtensionMethods
{

    public static bool BroadCastEvent(this GameObject go, string EventName)
    {
        EventsObserver eventHandler = go.GetComponent<EventsObserver>();
        if (eventHandler)
        {
            eventHandler.BroadCastEvent(EventName);
            return true;
        }

        return false;
    }

    public static void RegisterFunctionToEvent(this GameObject go, Action FunctionVoidToAdd, string NamedEvent)
    {
        EventsObserver eventHandler = go.GetComponent<EventsObserver>();
        if (eventHandler)
        {
            eventHandler.RegisterFunctionToEvent(FunctionVoidToAdd, NamedEvent);
        }
    }

}