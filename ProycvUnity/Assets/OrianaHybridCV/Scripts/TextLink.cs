using UnityEngine;
using System.Collections;

public class TextLink : ButtonBase
{
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
        if (TextRenderer)
        {
            TextRenderer.text = "<color=blue><i>" + gameObject.name + "</i></color>";
        }
    }

    void OnMouseExit()
    {
        if (TextRenderer)
        {
            TextRenderer.text = "<color=blue>" + gameObject.name + "</color>";
        }
    }


}
