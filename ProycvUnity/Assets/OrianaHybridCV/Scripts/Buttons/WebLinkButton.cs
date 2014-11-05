using UnityEngine;
using System.Collections;

public class WebLinkButton : ButtonBase{
    [System.Serializable]
    public class WebLinkButtonData{
        public Sprite NormalSprite = null;
        public Sprite MouseOverSprite = null;

        WebLinkButtonData(){
            NormalSprite = null;
            MouseOverSprite = null;
        }
    }

    [HideInInspector]
    public WebLinkButtonData WebLinkConfig;
    
    [Tooltip("Hola!")]
	public Sprite NormalSprite;
	public Sprite MouseOverSprite;

	private SpriteRenderer mySpriteRenderer;

	public override void Init(){
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	public override void OnSelected(){
		Application.ExternalEval("window.open('"+ButtonText+"','_blank')");
	}

	void OnMouseOver(){
        if (mySpriteRenderer && MouseOverSprite){
			mySpriteRenderer.sprite = MouseOverSprite;
		}
	}
	
	void OnMouseExit(){
        if (mySpriteRenderer && NormalSprite){
			mySpriteRenderer.sprite = NormalSprite;
		}
	}
}
