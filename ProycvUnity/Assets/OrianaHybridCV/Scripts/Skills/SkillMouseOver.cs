using UnityEngine;
using System.Collections;

public class SkillMouseOver : MonoBehaviour {

    public string SkillRank = "Rank 1/10";

    [Multiline]
    public string SkillDescription = "Soy una Skill";

    public TextMesh TextRenderer;

	// Use this for initialization
	void Start () {
        if (TextRenderer)
        {
            string SkillTitle = "<color=red><b>" + gameObject.name + "</b></color>\n";
            SkillRank = "<size=15><color=yellow>" + SkillRank + "</color>\n";
            SkillDescription = SkillDescription + "</size>";

            TextRenderer.text = SkillTitle + SkillRank + SkillDescription;
        }
	}
}
