using UnityEngine;
using System.Collections;

public class SkillMouseOver : MonoBehaviour {
    
    public string SkillRank = "Rank 1/10";
    [Multiline]
    public string SkillDescription = "Soy una Skill";
    public TextMesh TextRenderer;

    private string SkillTitle;
    private GameObject SkillText;

	// Use this for initialization
	void Start () {

        SkillText = GameObject.FindGameObjectWithTag("SkillText");
        TextRenderer = SkillText.GetComponentInChildren<TextMesh>();

        SkillTitle = "<color=red><b>" + gameObject.name + "</b></color>\n";
        SkillRank = "<size=15><color=yellow>" + SkillRank + "</color>\n";
        SkillDescription = SkillDescription + "</size>";

        UpdateText();
	}

    void OnMouseOver()
    {
        SkillText.SetActive(true);
        UpdateText();
    }

    void OnMouseExit()
    {
        SkillText.SetActive(false);
    }

    void UpdateText()
    {
        if (TextRenderer)
        {
            TextRenderer.text = SkillTitle + SkillRank + SkillDescription;
        }
    }

}
