using UnityEngine;
using System.Collections;

public class LinkScript : MonoBehaviour
{
    public string link = "";

    [HideInInspector]
    public Texture2D cursorTextureNormal;
    [HideInInspector]
    public Texture2D cursorTextureLink;
    [HideInInspector]
    public CursorMode cursorMode = CursorMode.Auto;
    [HideInInspector]
    public Vector2 hotSpot = Vector2.zero;

    void OnMouseOver()
    {
        if (link != "")
        {
            Cursor.SetCursor(cursorTextureLink, Vector2.zero, cursorMode);
        }
    }

    void OnMouseExit()
    {
        if (link != "")
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

    void OnMouseUpAsButton()
    {
        Handlelink();
    }

    void Handlelink()
    {
        if (link != "")
        {
            Application.ExternalEval("window.open('" + link + "','_blank')");
        }
    }

}
