using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ExperienceSubWindow : MonoBehaviour {

	[Multiline]
	public string WindowText = "Insert Text";

    public string QuestTitle = "Insert Text";
    public string QuestPlace = "Insert Text";
    [Multiline]
    public string QuestDescription = "Insert Text";

    public string QuestSecondaryTitle = "Insert Text";
    [Multiline]
    public string QuestSecondaryDescription = "Insert Text";
    public string Links = "Insert Text";
    
	public TextMesh TextMeshRenderer;

	// Use this for initialization
	void Start () {
        UpdateText();
	}

	[ContextMenu("UpdateText")]
	void UpdateText()
	{
		if(TextMeshRenderer)
		{
            List<string> SubWindowText = new List<string>();
            SubWindowText.Add("<size=25><b><color=white>" + QuestTitle + "</color></b></size>\n");
            SubWindowText.Add("<size=21><b><color=#FFDC35FF>" + QuestPlace + "</color></b></size>\n");
            SubWindowText.Add("<size=20><color=#DD7D7FF>" + QuestDescription + "</color></size>\n");
            SubWindowText.Add("<size=21><b><color=#FFDC35FF>" + QuestSecondaryTitle + "</color></b></size>\n");
            SubWindowText.Add("<size=20><color=#DD7D7FF>" + QuestSecondaryDescription + "</color></size>\n");
            SubWindowText.Add("<size=20><color=#62C0CEFF>" + Links + "</color></size>\n");

            TextMeshRenderer.text = "";
            foreach (string windowtext in SubWindowText)
            {
                TextMeshRenderer.text += windowtext;
            }
		}
	}

}
