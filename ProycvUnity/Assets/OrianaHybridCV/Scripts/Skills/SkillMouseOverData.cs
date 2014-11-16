using UnityEngine;
using System.Collections;

public class SkillMouseOverData : MonoBehaviour {
    public string SkillRank = "Rank 1/10";
    [Multiline]
    public string SkillDescription = "Soy una Skill";

    public Sprite SkillImage = null;
    public GameObject SkillPrefab = null;

    void Start()
    {
        GameObject mySkill = (GameObject)Instantiate(SkillPrefab, transform.position, transform.rotation);
        mySkill.name = name;
        SkillMouseOver mouseOverScript = mySkill.GetComponent<SkillMouseOver>();
        mouseOverScript.Data = this;
        mySkill.transform.parent = transform;
    }
}
