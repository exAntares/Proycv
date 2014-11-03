using UnityEngine;
using System.Collections;

public class ButtonBase : MonoBehaviour
{
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
    
    public void Awake()
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

	string GetHex(int myDecimal)
	{
		string alpha = "0123456789ABCDEF";
		string HexName = "" + alpha[myDecimal];
		return HexName;
	}
	
	protected string RGBToHex(Color ColorToHex)
	{
		float red = ColorToHex.r * 255;
		float green = ColorToHex.g * 255;
		float blue = ColorToHex.b * 255;
		
		string r1 = GetHex((int)Mathf.Floor(red / 16));
		string r2 = GetHex((int)Mathf.Floor(red % 16));
		string g1 = GetHex((int)Mathf.Floor(green / 16));
		string g2 = GetHex((int)Mathf.Floor(green % 16));
		string b1 = GetHex((int)Mathf.Floor(blue / 16));
		string b2 = GetHex((int)Mathf.Floor(blue % 16));
		
		string z = r1 + r2 + g1 + g2 + b1 + b2;
		
		return z;
	}

	public virtual string GetButtonText()
	{
		string End = "</color>";
		string Start = Selected ? "<color=#"+RGBToHex(TextSelectedColor)+">" : "<color=#"+RGBToHex(TextNormalColor)+">";
		return Start + ButtonText + End;
	}

}
