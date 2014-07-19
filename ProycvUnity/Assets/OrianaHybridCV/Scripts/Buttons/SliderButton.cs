using UnityEngine;
using System.Collections;

public class SliderButton : ButtonBase
{
	public enum Direction
	{
		Right,
		Left
	}

	public Direction SliderButtonDirection = Direction.Right;
	public SlideController SliderController;

	void OnMouseUpAsButton()
	{
		if(SliderController)
		{
			switch(SliderButtonDirection)
			{
			case Direction.Left:
				SliderController.PrevSlide();
				break;
			case Direction.Right:
				SliderController.NextSlide();
				break;
			}
		}
	}

	void OnMouseOver()
	{
		if(myAnimator)
		{
			if(ShouldShow())
			{
				myAnimator.Play("MouseOver");
			}
			else
			{
				myAnimator.Play("Idle");
			}
		}
	}
	
	void OnMouseExit()
	{
		if(myAnimator)
		{
			if(ShouldShow())
			{
				myAnimator.Play("MouseLeft");
			}
			else
			{
				myAnimator.Play("Idle");
			}
		}
	}

	bool ShouldShow()
	{
		switch(SliderButtonDirection)
		{
		case Direction.Left:
			return (SliderController.SlideIndex > 0);
		case Direction.Right:
			return (SliderController.SlideIndex < (SliderController.Slides.Count - 1) );
		default:
			return true;
		}
	}

}
