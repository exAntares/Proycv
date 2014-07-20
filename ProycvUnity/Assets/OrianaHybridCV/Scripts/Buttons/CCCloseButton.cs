using UnityEngine;
using System.Collections;

public class CCCloseButton : ButtonBase
{
	void OnMouseUpAsButton()
	{
		if(myAnimator)
		{
			myAnimator.SetTrigger("Hide");
		}

		GameObject UI = GameObject.Find("UI");
		if(UI)
		{
			UI.BroadcastMessage("EnableButton");
		}
	}

	void OnMouseOver()
	{
	}
	
	void OnMouseExit()
	{
	}
}
