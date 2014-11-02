using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillInfo : MonoBehaviour {

    public Vector3 MouseOffset = new Vector3( 2.0f, -2.0f, 0.0f);

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = transform.position.z;
        transform.position = p + MouseOffset;
	}

    public void ShowInfo()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void HideInfo()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
