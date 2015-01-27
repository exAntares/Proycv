using UnityEngine;
using System.Collections;

public class ExtensionColor : MonoBehaviour {
}

public static class ExtensionMethodsColor
{
    static string GetHex(int myDecimal)
    {
        string alpha = "0123456789ABCDEF";
        string HexName = "" + alpha[myDecimal];
        return HexName;
    }

    public static string ColorToHEX(this Color thisColor)
    {
        float red = thisColor.r * 255.0f;
        float green = thisColor.g * 255.0f;
        float blue = thisColor.b * 255.0f;

        string r1 = GetHex((int)Mathf.Floor(red / 16));
        string r2 = GetHex((int)Mathf.Floor(red % 16));
        string g1 = GetHex((int)Mathf.Floor(green / 16));
        string g2 = GetHex((int)Mathf.Floor(green % 16));
        string b1 = GetHex((int)Mathf.Floor(blue / 16));
        string b2 = GetHex((int)Mathf.Floor(blue % 16));

        string z = r1 + r2 + g1 + g2 + b1 + b2;

        return z.ToLower();
    }
}