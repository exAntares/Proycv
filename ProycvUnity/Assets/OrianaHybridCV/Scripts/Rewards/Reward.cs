using UnityEngine;
using System.Collections;

public class Reward : MonoBehaviour
{
    [HideInInspector]
    public RewardData Data;

    public Sprite ViewNormal;
    public Sprite ViewMouseOver;

    public SpriteRenderer Icon;
    public SpriteRenderer View;
    public TextMesh myText;

    
    private FloatingInfo floatingInformation;
    
    private string floatingInfo;
    private string Description;

    void Start()
    {
        floatingInformation = GameObject.FindGameObjectWithTag("SkillText").GetComponent<FloatingInfo>();

        if(Data)
        {
            myText.text = "<size="+Data.DescriptionSize+">"+Data.Description+"</size>";
            floatingInfo = Data.ExtendedDescription;
        }
    }

    void OnMouseOver()
    {
        View.sprite = ViewMouseOver;
        UpdateText();
        floatingInformation.ShowInfo(true);
    }

    void OnMouseExit()
    {
        View.sprite = ViewNormal;
        floatingInformation.ShowInfo(false);
    }

    void UpdateText()
    {
        if (floatingInformation)
        {
            floatingInformation.SetText(floatingInfo);
        }
    }
}
