using UnityEngine;
using System.Collections;

public class SkillMouseOver : MonoBehaviour {

    [Multiline]
    public string SkillText = "";
    public TextMesh TextRenderer;

	// Use this for initialization
	void Start () {
        if (TextRenderer)
        {
            TextRenderer.text = SkillText;
        }
	}
}
