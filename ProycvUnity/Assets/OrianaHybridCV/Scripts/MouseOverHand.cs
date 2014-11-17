using UnityEngine;
using System.Collections;

public class MouseOverHand : MonoBehaviour {

    public Texture2D cursorNormal = null;
    public Texture2D cursorMouseOver = null;
    protected CursorMode cursorMode = CursorMode.Auto;
    protected Vector2 hotSpot = Vector2.zero;

    void OnMouseOver()
    {
        Cursor.SetCursor(cursorMouseOver, Vector2.zero, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
