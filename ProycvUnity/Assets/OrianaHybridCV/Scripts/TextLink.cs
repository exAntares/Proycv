using UnityEngine;
using System.Collections;

public class TextLink : ButtonBase
{
    protected bool bMouseOver = false;
    public string selectedHEX;
    public override void Init()
    {
        UpdateText();
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
        selectedHEX = RGBToHex(TextSelectedColor);

        string normalColor = "<color=#" + RGBToHex(TextNormalColor) + ">";
        string mouseOverColor = "<color=#" + RGBToHex(TextSelectedColor) + ">";
        
        string Start = (bMouseOver ? mouseOverColor : normalColor) + (bMouseOver ? "<i>" : "");
        string End = (bMouseOver ? "</i>" : "") + "</color>";
        return Start + gameObject.name + End;
    }

}
