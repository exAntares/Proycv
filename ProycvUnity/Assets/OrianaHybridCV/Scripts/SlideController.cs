using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlideController : MonoBehaviour {

	public int SlideIndex = 0;
	public List<GameObject> Slides;

	// Use this for initialization
	void Start () {

		GameObject[] _Slides = GameObject.FindGameObjectsWithTag("Slide");
		foreach(GameObject go in _Slides)
		{
			Slides.Add(go);
		}

		if(SlideIndex < Slides.Count)
		{
			ShowSlide(Slides[SlideIndex]);
		}

	}

	void OnEnable()
	{
		if(SlideIndex < Slides.Count)
		{
			ShowSlide(Slides[SlideIndex]);
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
