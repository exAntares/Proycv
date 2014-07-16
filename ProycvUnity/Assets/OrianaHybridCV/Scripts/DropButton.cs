using UnityEngine;
using System.Collections;

public class DropButton : ButtonBase
{
	void ToggleSelected()
	{
		if(myAnimator)
		{
			if(Selected)
			{
				myAnimator.Play("Idle");
			}
			else
			{
				myAnimator.Play("Selected");
			}
		}

		Selected = !Selected;
		UpdateText();
	}

	void OnMouseUpAsButton()
	{
		ToggleSelected();
		OnButtonPressed();
	}
}
