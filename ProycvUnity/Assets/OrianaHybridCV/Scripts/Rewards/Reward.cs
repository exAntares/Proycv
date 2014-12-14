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

    private FloatingReward floatingInformation;
    
    private GameObject ExtendedDescriptionPrefab;
    private GameObject ExtendedDescriptionInstance;

    private string floatingInfo;
    private string Description;

    void Start()
    {
        floatingInformation = GameObject.FindGameObjectWithTag("RewardText").GetComponent<FloatingReward>();
        
        if(Data)
        {
            myText.text = "<color=#" + Data.DescriptionColor.ColorToHEX() + "><size=" + Data.DescriptionSize + ">" + Data.Description + "</size></color>";

            Icon.sprite = Data.Icon;



            if (floatingInformation)
            {
                floatingInfo = Data.ExtendedDescription;
                ExtendedDescriptionPrefab = Data.ExtendedDescriptionPrefab;
                if (ExtendedDescriptionPrefab)
                {
                    ExtendedDescriptionInstance = Instantiate(ExtendedDescriptionPrefab, floatingInformation.transform.position, floatingInformation.transform.rotation) as GameObject;
                    ExtendedDescriptionInstance.transform.parent = floatingInformation.transform;
                    ExtendedDescriptionInstance.SetActive(false);
                }
            }
        }
    }

    void OnMouseOver()
    {
        View.sprite = ViewMouseOver;
        floatingInformation.ShowInfo(true);

        if (ExtendedDescriptionInstance)
        {
            ExtendedDescriptionInstance.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        View.sprite = ViewNormal;
        floatingInformation.ShowInfo(false);

        if (ExtendedDescriptionInstance)
        {
            ExtendedDescriptionInstance.SetActive(false);
        }
    }

    void OnDestroy()
    {
        if(ExtendedDescriptionInstance)
        {
            Destroy(ExtendedDescriptionInstance);
        }
    }
}
