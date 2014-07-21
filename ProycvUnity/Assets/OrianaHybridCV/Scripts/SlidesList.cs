using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlidesList : MonoBehaviour
{
	public int SlideIndex = 0;
	public List<GameObject> Slides;
	
	// Use this for initialization
	void Awake ()
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			Transform childTrans = transform.GetChild(i);
			if(childTrans)
			{
				if(childTrans.tag == "Slide")
				{
					Slides.Add(childTrans.gameObject);
				}
			}
		}
	}

	public void EnableList()
	{
		if(SlideIndex < Slides.Count)
		{
			ShowSlide(Slides[SlideIndex]);
		}
	}

	public void DisableList()
	{
		if(SlideIndex < Slides.Count)
		{
			HideSlide(Slides[SlideIndex]);
		}
	}

	[ContextMenu("NextSlide")]
	public void NextSlide()
	{
		if(SlideIndex < Slides.Count - 1)
		{
			HideSlide(Slides[SlideIndex]);
			SlideIndex++;
			ShowSlide(Slides[SlideIndex]);
		}
	}
	
	[ContextMenu("PrevSlide")]
	public void PrevSlide()
	{
		if(SlideIndex > 0)
		{
			HideSlide(Slides[SlideIndex]);
			SlideIndex--;
			ShowSlide(Slides[SlideIndex]);
		}
	}
	
	void HideSlide(GameObject Slide)
	{
		Animator SlideAnimator = Slide.GetComponent<Animator>();
		if(SlideAnimator)
		{
			SlideAnimator.Play("Hide");
		}
	}
	
	void ShowSlide(GameObject Slide)
	{
		Animator SlideAnimator = Slide.GetComponent<Animator>();
		if(SlideAnimator)
		{

			SlideAnimator.Play("Show");
		}
	}
}
