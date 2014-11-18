using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnEventSpawn : OnEvent<SpawnGameObject>
{
}

[System.Serializable]
public class SpawnGameObject : EventExecuterBase
{
    public GameObject SpawnPrefab = null;
    public GameObject parent = null;
    public Transform newTransform;

    public override void DoAction()
    {
        GameObject spawnedObj = (GameObject)GameObject.Instantiate(SpawnPrefab, newTransform.position, newTransform.rotation);
        if (parent)
        {
            spawnedObj.transform.parent = parent.transform;
        }
    }
}