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
    
    public GameObject TemplateInstancePrefab;
    public GameObject TemplateInstance;

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
        SpawnView();
    }

    [ContextMenu("SpawnView")]
    void SpawnView()
    {
        if (TemplateInstancePrefab != null)
        {
            if (TemplateInstance != null)
            {
                DestroyImmediate(TemplateInstance);
            }

            TemplateInstance = Instantiate(TemplateInstancePrefab, transform.position, transform.rotation) as GameObject;
            TemplateInstance.transform.parent = transform;


            textsObjects.Title = TemplateInstance.transform.FindChild("Title").GetComponent<TextMesh>();
            textsObjects.Info = TemplateInstance.transform.FindChild("Info").GetComponent<TextMesh>();
            textsObjects.Description = TemplateInstance.transform.FindChild("Description").FindChild("DescriptionText").GetComponent<TextMesh>();
            textsObjects.Experience = TemplateInstance.transform.FindChild("Experience").FindChild("ExperienceAmmount").GetComponent<TextMesh>();
            textsObjects.Money = TemplateInstance.transform.FindChild("MoneyAmmount").GetComponent<TextMesh>();
        }
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
