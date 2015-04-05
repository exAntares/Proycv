using UnityEngine;
using System.Collections;

public class SkillMouseOverData : MonoBehaviour {
    public string SkillRank = "Rank 1/10";
    [Multiline]
    public string SkillDescription = "Soy una Skill";

    public Sprite SkillImage = null;
    public GameObject SkillPrefab = null;
    
    [HideInInspector]
    public GameObject mySkill = null;

    void Start()
    {
        Spawn();
    }

    [ContextMenu("SpawnSkill")]
    void Spawn()
    {
        if (mySkill)
        {
            DestroyImmediate(mySkill);
        }

        mySkill = Instantiate(SkillPrefab, transform.position, transform.rotation) as GameObject;
        mySkill.name = name;
        SkillMouseOver mouseOverScript = mySkill.GetComponent<SkillMouseOver>();
        mouseOverScript.Data = this;
        mySkill.transform.parent = transform;
        mySkill.transform.localScale = SkillPrefab.transform.localScale;
    }
}
