using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExperienceSubwindow : MonoBehaviour
{
    [System.Serializable]
    public class TextComponents
    {
        public TextMesh Title;
        public TextMesh Info;
        public TextMesh Description;
        public TextMesh Experience;
        public TextMesh Money;
    }

    public TextComponents textsObjects;

    public string QuestTitle = "Insert Text";
    public string QuestRequester = "Insert Text";
    public string QuestLocalization = "Insert Text";
    public string QuestDuration = "Insert Text";
    public string QuestObjectives = "Insert Text";

    [Multiline]
    public string QuestDescription = "Insert Text";

    public string QuestExpReward = "50";
    public string QuestMoneyReward = "100";
    
    // Use this for initialization
    void Start()
    {
        UpdateText();
    }

    [ContextMenu("UpdateText")]
    void UpdateText()
    {
        if (textsObjects.Title)
        {
            textsObjects.Title.text = QuestTitle;
        }

        if (textsObjects.Info)
        {
            textsObjects.Info.text = "<color=orange>Quest requester:</color> " + QuestRequester
                + "\n<color=orange>Localization:</color> " + QuestLocalization
                + "\n<color=orange>Duration:</color> " + QuestDuration
                + "\n<color=orange>Objectives:</color> " + QuestObjectives;
        }

        if (textsObjects.Description)
        {
            textsObjects.Description.text = QuestDescription;
        }

        if (textsObjects.Experience)
        {
            textsObjects.Experience.text = "+" + QuestExpReward;
        }

        if (textsObjects.Money)
        {
            textsObjects.Money.text = "+" + QuestMoneyReward;
        }
    }

}
