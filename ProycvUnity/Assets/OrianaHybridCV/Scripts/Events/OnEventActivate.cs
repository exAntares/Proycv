using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnEventActivate : OnEvent<ActivateObjectAction>
{
}

[System.Serializable]
public class ActivateObjectAction : EventExecuterBase
{
    public GameObject ObjectInSceneToActivate = null;
    public bool Activate = true;

    public override void DoAction()
    {
        ObjectInSceneToActivate.SetActive(Activate);
    }
}

