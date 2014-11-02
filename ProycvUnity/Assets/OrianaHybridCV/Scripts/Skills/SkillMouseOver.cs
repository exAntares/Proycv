using UnityEngine;
using System.Collections;

public class SkillMouseOver : MonoBehaviour {
    
    public string SkillRank = "Rank 1/10";
    [Multiline]
    public string SkillDescription = "Soy una Skill";
    public TextMesh TextRenderer;

    private string SkillTitle;
    private GameObject SkillText;
    private SkillInfo skillInformation;

	// Use this for initialization
	void Start () {

        SkillText = GameObject.FindGameObjectWithTag("SkillText");
        TextRenderer = SkillText.GetComponentInChildren<TextMesh>();
        skillInformation = SkillText.GetComponent<SkillInfo>();

        SkillTitle = "<color=red><b>" + gameObject.name + "</b></color>\n";
        SkillRank = "<size=15><color=yellow>" + SkillRank + "</color>\n";
        SkillDescription = SkillDescription + "</size>";

        UpdateText();
	}

    void OnMouseOver()
    {
        UpdateText();
        skillInformation.ShowInfo(true);
    }

    void OnMouseExit()
    {
        skillInformation.ShowInfo(false);
    }

    void UpdateText()
    {
        if (TextRenderer)
        {
            TextRenderer.text = SkillTitle + SkillRank + SkillDescription;
        }
    }

}
