using UnityEngine;
using System.Collections;

[System.Serializable]
public class CursorData : MonoBehaviour
{
    public Texture2D cursorTextureNormal;
    public Texture2D cursorTextureLink;
    [HideInInspector]
    public CursorMode cursorMode = CursorMode.Auto;
    [HideInInspector]
    public Vector2 hotSpot = Vector2.zero;

    void OnMouseOver()
    {
        Cursor.SetCursor(cursorTextureLink, Vector2.zero, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
