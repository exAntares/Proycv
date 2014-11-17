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
        gameObject.BroadCastEvent("OnFinishStart");
    }

    private void OnDestroy()
    {
        DelegatesByEventName.Clear();
    }

    #endregion
}

#region EventDefinitions

//[System.Serializable]
//public class EventSendMessages : EventExecuterBase
//{
//    [System.Serializable]
//    public class Mensaje
//    {
//        public GameObject Target = null;
//        public string Message = "";
//        public UnityEngine.Object Params = null;

//    };

//    public Mensaje MessageForSendMessage;

//    public override void DoAction()
//    {
//        if (MessageForSendMessage != null && MessageForSendMessage.Target != null)
//        {
//            MessageForSendMessage.Target.SendMessage(MessageForSendMessage.Message, MessageForSendMessage.Params, SendMessageOptions.DontRequireReceiver);
//        }
//    }
//}



#endregion

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