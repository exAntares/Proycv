using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnEventPlaySound : OnEvent<PlaySound>
{
}

[System.Serializable]
public class PlaySound : EventExecuterBase
{
    public AudioClip MySoundToPlay = null;
    public float Volumen = 1.0f;
    public Vector3 SoundPos = Vector3.zero;

    public override void DoAction()
    {
        if (MySoundToPlay)
        {
            AudioSource.PlayClipAtPoint(MySoundToPlay, SoundPos, Volumen);
        }
    }
}
