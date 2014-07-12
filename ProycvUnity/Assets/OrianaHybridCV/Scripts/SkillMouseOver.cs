using UnityEngine;
using System.Collections;

public class SkillMouseOver : MonoBehaviour {

	public SpriteRenderer ButtonFX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseOver()
	{ 
		if(ButtonFX)
		{
			ButtonFX.enabled = true;
		}
	}

	void OnMouseExit()
	{ 
		if(ButtonFX)
		{
			ButtonFX.enabled = false;
		}
	}


}
