using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlideController : MonoBehaviour
{
	public Dictionary<string, SlidesList> SlidesList = new Dictionary<string, SlidesList>();
	public SlidesList CurrentSlideList;

	// Use this for initialization
	void Awake ()
	{
		GameObject[] SlidersLists = GameObject.FindGameObjectsWithTag("SliderList");
		foreach(GameObject SL in SlidersLists)
		{
			SlidesList List = SL.GetComponent<SlidesList>();
			if(List)
			{
				SlidesList[List.name] = List;
			}
		}
	}

	public void SetCurrentList(string ListName)
	{
		if(SlidesList.ContainsKey(ListName))
		{
			if(CurrentSlideList)
			{
				CurrentSlideList.DisableList();
			}

			CurrentSlideList = SlidesList[ListName];
			CurrentSlideList.SlideIndex = 0;
			CurrentSlideList.EnableList();
		}
		else
		{
            Debug.LogWarning("There is no such List: " + ListName);
		}
	}


	[ContextMenu("NextSlide")]
	public void NextSlide()
	{
		if(CurrentSlideList)
		{
			CurrentSlideList.NextSlide();
		}
	}

	[ContextMenu("PrevSlide")]
	public void PrevSlide()
	{
		if(CurrentSlideList)
		{
			CurrentSlideList.PrevSlide();
		}
	}
	
	public int GetSlideIndex()
	{
		if(CurrentSlideList)
		{
			return CurrentSlideList.SlideIndex;
		}

		return 0;
	}

	public int GetSlidesCount()
	{
		if(CurrentSlideList)
		{
			return CurrentSlideList.Slides.Count;
		}

		return 0;
	}

}
