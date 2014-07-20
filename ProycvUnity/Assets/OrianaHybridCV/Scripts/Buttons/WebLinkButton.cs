using UnityEngine;
using System.Collections;

public class WebLinkButton : ButtonBase
{
	public Sprite NormalSprite;
	public Sprite MouseOverSprite;

	private SpriteRenderer mySpriteRenderer;

	public override void Init()
	{
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	public override void OnSelected()
	{
		//Debug.Log("TryTo Open Window");
		Application.ExternalEval("window.open('"+ButtonText+"','_blank')");
	}

	void OnMouseOver()
	{
		if(mySpriteRenderer)
		{
			mySpriteRenderer.sprite = MouseOverSprite;
		}
	}
	
	void OnMouseExit()
	{
		if(mySpriteRenderer)
		{
			mySpriteRenderer.sprite = NormalSprite;
		}
	}
}
