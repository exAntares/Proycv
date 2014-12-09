using UnityEngine;
using System.Collections;

public class RewardData : MonoBehaviour
{
    public Sprite Icon = null;

    public int DescriptionSize = 12;
    public Color DescriptionColor = Color.white;
    [Multiline]
    public string Description;
    [Multiline]
    public string ExtendedDescription;
    public Reward RewardPrefab;
    
    [HideInInspector]
    public GameObject View = null;

    void Start()
    {
        SpawnView();
    }

    [ContextMenu("SpawnView")]
    void SpawnView()
    {
        if (View)
        {
            DestroyImmediate(View);
            View = null;
        }

        View = Instantiate(RewardPrefab.gameObject, transform.position, transform.rotation) as GameObject;
        View.name = name;
        Reward rewardScript = View.GetComponent<Reward>();
        rewardScript.Data = this;
        View.transform.parent = transform;
    }


}
