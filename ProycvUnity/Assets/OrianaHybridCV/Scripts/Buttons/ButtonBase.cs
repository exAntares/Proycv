using UnityEngine;
using System.Collections;

public class ButtonBase : MonoBehaviour
{
    [System.Serializable]
    public class TextData
    {
        public string ButtonText = "";
        public Color TextNormalColor = Color.yellow;
        public Color TextSelectedColor = Color.white;
        public TextMesh TextRenderer;

        TextData()
        {
            ButtonText = "";
            TextNormalColor = Color.yellow;
            TextSelectedColor = Color.white;
        }
    }

    [HideInInspector]
    public TextData TextConfig;

	public string ButtonText = "";

	public TextMesh TextRenderer;
	public Animator myAnimator;

	public Color TextNormalColor = Color.yellow;
	public Color TextSelectedColor = Color.white;
	
	protected bool Selected = false;
	protected bool ButtonEnabled = true;

    public Texture2D cursorTextureNormal;
    public Texture2D cursorTextureLink;
    protected CursorMode cursorMode = CursorMode.Auto;
    protected Vector2 hotSpot = Vector2.zero;
    protected AudioClip ButtonSound;

    public virtual void Awake()
    {
    }

	public void DisableButton()
	{
		ButtonEnabled = false;
	}

	public void EnableButton()
	{
		ButtonEnabled = true;
	}

	// Use this for initialization
	void Start ()
	{
		Init();
	}

	public virtual void Init()
	{
        ButtonSound = Resources.Load<AudioClip>("SFX/Sounds/212003__pegtel__button-tap-1");
		UpdateText();
	}

	public virtual void OnSelected()
	{

	}

	public virtual void OnUnSelected()
	{
	}

	[ContextMenu("StopSelect")]
	public void StopSelect()
	{
		Selected = false;

		if(myAnimator)
		{
			myAnimator.Play("Idle");
		}

		UpdateText();

		OnUnSelected();
	}

	[ContextMenu("StartSelect")]
	public void StartSelect()
	{
		Selected = true;
		
		if(myAnimator)
		{
			myAnimator.Play("Selected");
		}
		
		UpdateText();
		
		OnSelected();
	}

	void OnMouseUpAsButton()
	{
		if(ButtonEnabled)
		{
			StartSelect();
            
            if (ButtonSound)
            {
                AudioSource.PlayClipAtPoint(ButtonSound, Vector3.zero);
            }
		}
	}

	void OnMouseOver()
	{
        Cursor.SetCursor(cursorTextureLink, Vector2.zero, cursorMode);

		if(ButtonEnabled && myAnimator && !Selected)
		{
			myAnimator.Play("MouseOver");
		}

		UpdateText();
	}

	void OnMouseExit()
	{
        Cursor.SetCursor(null, Vector2.zero, cursorMode);

		if(ButtonEnabled && myAnimator && !Selected)
		{
			myAnimator.Play("Idle");
		}

		UpdateText();
	}

	[ContextMenu("UpdateText")]
	public virtual void UpdateText()
	{
		if(TextRenderer)
		{
			TextRenderer.text = GetButtonText();
		}
	}

	public virtual string GetButtonText()
	{
		string End = "</color>";
        string Start = Selected ? "<color=#" + TextSelectedColor.ColorToHEX() + ">" : "<color=#" + TextNormalColor.ColorToHEX() + ">";
		return Start + ButtonText + End;
	}

}
