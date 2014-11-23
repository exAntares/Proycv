using UnityEngine;
using System.Collections;

public class RewardData : MonoBehaviour
{
    public Sprite Icon = null;
    [Multiline]
    public string Description;
    [Multiline]
    public string ExtendedDescription;
    public Reward RewardPrefab;

    void Start()
    {
        GameObject myRewardView = Instantiate(RewardPrefab.gameObject, transform.position, transform.rotation) as GameObject;
        myRewardView.name = name;
        Reward rewardScript = myRewardView.GetComponent<Reward>();
        rewardScript.Data = this;
        myRewardView.transform.parent = transform;
    }
}
