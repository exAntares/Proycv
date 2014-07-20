using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ToggleEnableMouseOver : MonoBehaviour {

    public List<GameObject> ObjectsToToggle;

    void OnMouseOver()
    {
        foreach(GameObject go in ObjectsToToggle)
        {
            go.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        foreach (GameObject go in ObjectsToToggle)
        {
            go.SetActive(false);
        }
    }
}
