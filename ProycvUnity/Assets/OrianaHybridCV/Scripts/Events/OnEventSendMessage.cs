using UnityEngine;
using System.Collections;

public class OnEventSendMessage : OnEvent<EventSendMessages>
{
}

[System.Serializable]
public class EventSendMessages : EventExecuterBase
{
    [System.Serializable]
    public class MessageClass
    {
        public GameObject Target = null;
        public string Message = "";
        public UnityEngine.Object Params = null;
    };

    public MessageClass myMessage;

    public override void DoAction()
    {
        if (myMessage != null && myMessage.Target != null)
        {
            myMessage.Target.SendMessage(myMessage.Message, myMessage.Params, SendMessageOptions.DontRequireReceiver);
        }
    }
}