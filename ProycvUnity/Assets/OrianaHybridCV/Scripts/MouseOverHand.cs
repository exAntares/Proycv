using UnityEngine;
using System.Collections;

public class MouseOverHand : MonoBehaviour {

    public Texture2D cursorNormal = null;
    public Texture2D cursorMouseOver = null;
    protected CursorMode cursorMode = CursorMode.Auto;
    protected Vector2 hotSpot = Vector2.zero;

    void OnMouseOver()
    {
        //Animations that move objects will never call OnMouseExit, so we invoke a "security" normal mouse
        CancelInvoke();
        SetMouseOverCursor();
        Invoke("SetNormalMouse", 0.2f);
    }

    void OnMouseExit()
    {
        SetNormalMouse();
    }

    public void SetMouseOverCursor()
    {
        Cursor.SetCursor(cursorMouseOver, Vector2.zero, cursorMode);
    }

    public void SetNormalMouse()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
