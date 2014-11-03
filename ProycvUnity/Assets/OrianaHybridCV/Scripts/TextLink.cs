using UnityEngine;
using System.Collections;

public class TextLink : ButtonBase
{
    protected bool bMouseOver = false;

    public override void Init()
    {
        if (TextRenderer)
        {
            TextRenderer.text = "<color=blue>" + gameObject.name + "</color>";
        }
    }

    public override void OnSelected()
    {
        Application.ExternalEval("window.open('" + ButtonText + "','_blank')");
    }

    void OnMouseOver()
    {
        bMouseOver = true;
        Cursor.SetCursor(cursorTextureLink, Vector2.zero, cursorMode);
        UpdateText();
    }

    void OnMouseExit()
    {
        bMouseOver = false;
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        UpdateText();
    }

    public override string GetButtonText()
    {
        string Start = "<color=blue>" +  (bMouseOver ? "<i>" : "");
        string End = (bMouseOver ? "</i>" : "") + "</color>";
        return Start + gameObject.name + End;
    }

}
