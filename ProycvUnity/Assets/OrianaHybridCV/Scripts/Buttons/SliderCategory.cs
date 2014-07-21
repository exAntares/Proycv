using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SliderCategory : ButtonBase
{
	public bool DefaultCategory = false;
	public SlideController SlidesController;

	private List<SliderCategory> OtherSlidersCategory = new List<SliderCategory>();

	public override void Init ()
	{
		base.Init();
		GameObject[] AllSlidersCategory = GameObject.FindGameObjectsWithTag("SliderCategory");
		foreach(GameObject slidercategory in AllSlidersCategory)
		{
			SliderCategory SCategory = slidercategory.GetComponent<SliderCategory>();
			if(SCategory!= this)
			{
				OtherSlidersCategory.Add(SCategory);
			}
		}

		if(DefaultCategory)
		{
			StartSelect();
		}
	}

	public override void OnSelected()
	{
		if(myAnimator)
		{
			myAnimator.SetBool("Selected", Selected);
		}

		foreach(SliderCategory SC in OtherSlidersCategory)
		{
			SC.StopSelect();
		}

		if(SlidesController)
		{
			SlidesController.SetCurrentList(gameObject.name);
		}
	}
	
	public override void OnUnSelected()
	{
		if(myAnimator)
		{
			myAnimator.SetBool("Selected", Selected);
		}
	}

	void OnMouseExit()
	{
		if(ButtonEnabled && myAnimator && !Selected)
		{
			myAnimator.Play("MouseExit");
		}
		
		UpdateText();
	}

	void FixedUpdate()
	{
		if(TextRenderer)
		{
			TextRenderer.color = TextNormalColor;
		}
	}

	public override string GetButtonText()
	{
		return gameObject.name;
	}

}
