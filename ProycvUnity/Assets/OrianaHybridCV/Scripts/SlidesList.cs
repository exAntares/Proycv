using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlidesList : MonoBehaviour
{
    [System.Serializable]
    public class mySlidesList
    {
        public float scale = 1.0f;
        public Sprite SlidesImage;
    }

    public GameObject SlidesPrefab;
    public List<mySlidesList> SlidesImages;

    [HideInInspector]
	public int SlideIndex = 0;
    [HideInInspector]
	public List<GameObject> Slides;
	
	// Use this for initialization
	void Awake ()
	{
        foreach (mySlidesList slideSprite in SlidesImages)
        {
            GameObject newSlide = Instantiate(SlidesPrefab, transform.position, transform.rotation) as GameObject;
            SpriteRenderer spriterenderer = newSlide.GetComponent<SpriteRenderer>();
            spriterenderer.sprite = slideSprite.SlidesImage;
            newSlide.transform.localScale = Vector3.one * slideSprite.scale;
            newSlide.transform.parent = transform;
        }

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
