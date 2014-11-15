using UnityEngine;
using System.Collections;

public class SkillMouseOver : MonoBehaviour {

    public SkillMouseOverData Data;

    public string SkillRank = "Rank 1/10";
    [Multiline]
    public string SkillDescription = "Soy una Skill";
    public TextMesh TextRenderer;
    public SpriteRenderer ImageRenderer;

    private string SkillTitle;
    private GameObject SkillText;
    private SkillInfo skillInformation;
    private TextMesh SkillTextRenderer;

	// Use this for initialization
	void Start () {

        SkillText = GameObject.FindGameObjectWithTag("SkillText");
        skillInformation = SkillText.GetComponent<SkillInfo>();
        TextRenderer = skillInformation.TextRenderer;
        SkillTextRenderer = GetComponentInChildren<TextMesh>();

        if (Data)
        {
            SkillText = GameObject.FindGameObjectWithTag("SkillText");

            SkillTitle = "<color=orange><b>" + gameObject.name + "</b></color>\n";
            SkillRank = "<size=20><color=#dcc06c>" + "Rank: " + Data.SkillRank + "</color>\n";
            SkillDescription = Data.SkillDescription + "</size>";
            ImageRenderer.sprite = Data.SkillImage;

            UpdateText();
        }

        SkillTextRenderer.text = Data.SkillRank;
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
